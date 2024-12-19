namespace Recordboxed.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.Records.Any())
            {
                return;  
            }

            var records = new Record[]
            {
                new Record{Title="Phase Contrast From Recollection", Artist="Akhira Sano", Meta="ambient,experimental"},
                new Record{Title="Crossroads", Artist="Feral", Meta="hypnotic,techno"},
                new Record{Title="Total Blue", Artist="Total Blue", Meta="ambient,jazz,vaporwave"},
            };

            context.Records.AddRange(records);
            context.SaveChanges();
        }
    }
}