using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormApp1
{
    public static class EventRepository
    {
        public static SortedDictionary<string, Queue<Event>> EventsByCategory = new SortedDictionary<string, Queue<Event>>(StringComparer.OrdinalIgnoreCase);
        public static HashSet<string> Categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public static Stack<Event> LastViewed = new Stack<Event>();
        public static Queue<Event> SubmissionQueue = new Queue<Event>();
        private static Dictionary<string, int> CategorySearchFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        static EventRepository()
        {
            var samples = new List<Event>
            {
                new Event{Title="Community Clean-up", Category="Environment", Date=DateTime.Now.AddDays(3), Description="Join us for a clean-up drive in the central park."},
                new Event{Title="Youth Soccer Tournament", Category="Sports", Date=DateTime.Now.AddDays(7), Description="Local teams compete for the youth cup."},
                new Event{Title="Health Awareness Fair", Category="Health", Date=DateTime.Now.AddDays(5), Description="Free check-ups and wellness workshops."},
                new Event{Title="Town Hall Meeting", Category="Government", Date=DateTime.Now.AddDays(2), Description="Discuss municipal development plans."},
                new Event{Title="Recycling Workshop", Category="Environment", Date=DateTime.Now.AddDays(10), Description="Learn how to recycle properly."},
                new Event{Title="Adult Education Info Session", Category="Education", Date=DateTime.Now.AddDays(12), Description="Courses and registration details."},
                new Event{Title="Road Safety Campaign", Category="Safety", Date=DateTime.Now.AddDays(4), Description="Safety tips and helmet distribution."},
                new Event{Title="Community Market Day", Category="Economy", Date=DateTime.Now.AddDays(6), Description="Local sellers and crafts."},
                new Event{Title="Library Story Hour", Category="Education", Date=DateTime.Now.AddDays(1), Description="Children's story reading session."},
                new Event{Title="Senior Social", Category="Social", Date=DateTime.Now.AddDays(8), Description="Activities for seniors."},
                new Event{Title="Food Drive", Category="Charity", Date=DateTime.Now.AddDays(9), Description="Donate non-perishables to help families."},
                new Event{Title="Public Transport Forum", Category="Government", Date=DateTime.Now.AddDays(11), Description="Discuss bus routes and schedules."},
                new Event{Title="Beach Cleanup", Category="Environment", Date=DateTime.Now.AddDays(14), Description="Bring gloves and water."},
                new Event{Title="Local Musicians Night", Category="Culture", Date=DateTime.Now.AddDays(13), Description="Live performances by local artists."},
                new Event{Title="Free Dental Clinic", Category="Health", Date=DateTime.Now.AddDays(15), Description="Dental screenings and basic care."},
                new Event{Title="Coding Workshop for Teens", Category="Education", Date=DateTime.Now.AddDays(16), Description="Intro to Python and web dev."}
            };

            foreach (var ev in samples) AddEvent(ev);
        }

        public static void AddEvent(Event ev)
        {
            if (!EventsByCategory.ContainsKey(ev.Category))
                EventsByCategory[ev.Category] = new Queue<Event>();

            EventsByCategory[ev.Category].Enqueue(ev);
            Categories.Add(ev.Category);
        }

        public static void SubmitNewEvent(Event ev) => SubmissionQueue.Enqueue(ev);

        public static void ProcessSubmissions()
        {
            while (SubmissionQueue.Count > 0)
                AddEvent(SubmissionQueue.Dequeue());
        }

        public static List<Event> SearchEvents(string keyword, string category, DateTime? date)
        {
            var all = EventsByCategory.Values.SelectMany(q => q);

            var filtered = all.Where(ev =>
                (string.IsNullOrEmpty(keyword)
                    || ev.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                    || ev.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                && (string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase)
                    || ev.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                && (!date.HasValue || ev.Date.Date == date.Value.Date)
            ).ToList();

            if (!string.IsNullOrEmpty(category) &&
                !string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase))
            {
                if (!CategorySearchFrequency.ContainsKey(category))
                    CategorySearchFrequency[category] = 0;
                CategorySearchFrequency[category]++;
            }

            if (filtered.Any())
                LastViewed.Push(filtered.First());

            return filtered.OrderBy(e => e.Date).ToList();
        }

        public static List<Event> GetSmartRecommendations(int take = 5)
        {
            if (!CategorySearchFrequency.Any())
            {
                return EventsByCategory.Values.SelectMany(q => q)
                    .Where(e => e.Date >= DateTime.Now)
                    .OrderBy(e => e.Date)
                    .Take(take)
                    .ToList();
            }

            var topCats = CategorySearchFrequency.OrderByDescending(kv => kv.Value)
                                                 .Select(kv => kv.Key)
                                                 .ToList();
            var recs = new List<Event>();

            foreach (var cat in topCats)
            {
                if (!EventsByCategory.ContainsKey(cat)) continue;

                foreach (var e in EventsByCategory[cat].Where(ev => ev.Date >= DateTime.Now))
                {
                    if (!recs.Contains(e))
                        recs.Add(e);
                    if (recs.Count >= take) break;
                }
                if (recs.Count >= take) break;
            }

            if (recs.Count < take)
            {
                var fill = EventsByCategory.Values.SelectMany(q => q)
                    .Where(e => e.Date >= DateTime.Now && !recs.Contains(e))
                    .OrderBy(e => e.Date)
                    .Take(take - recs.Count);
                recs.AddRange(fill);
            }

            return recs;
        }

        public static List<Event> GetLastViewed(int top = 5) => LastViewed.Take(top).ToList();

        public static List<Event> GetAllEventsSorted(string sortBy = "Date", bool ascending = true)
        {
            var all = EventsByCategory.Values.SelectMany(q => q);
            List<Event> sorted;

            switch (sortBy.ToLowerInvariant())
            {
                case "title":
                    sorted = ascending ? all.OrderBy(e => e.Title).ToList() : all.OrderByDescending(e => e.Title).ToList();
                    break;
                case "category":
                    sorted = ascending ? all.OrderBy(e => e.Category).ToList() : all.OrderByDescending(e => e.Category).ToList();
                    break;
                default:
                    sorted = ascending ? all.OrderBy(e => e.Date).ToList() : all.OrderByDescending(e => e.Date).ToList();
                    break;
            }

            return sorted;
        }
    }
}
