using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul5_1302200010
{
    class SayaTubeVideo
    {
        private int id;
        private String title;
        private int playCount;
        public int GetPlaycount()
        {
            return playCount;
        }
        public string GetTitle()
        {
            return title;
        }
        public SayaTubeVideo(String a, int b)
        {
            Debug.Assert(a.Length <= 200 && a.Length != null, "Karakter Judul maksimal adalah 200 dan tidak boleh kosong");
            Random rnd = new Random();
            id = rnd.Next(0, 100000);
            string dig5 = id.ToString("D5");
            title = a;
            playCount = b;
        }
        public int increasePlayCount(int a)
        {
            Debug.Assert(a>=0 && a <= 25000000, "Maksimal play count adalah 25.000.000");
            Debug.Assert(a <= int.MaxValue);
            try
            {
                playCount = checked(a);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("play count melebihi batas overflow" + e.Message);
                playCount = 0;
            }
            return playCount;
        }
        public void printVideoDetails()
        {
            Console.WriteLine("id           : " + id);
            Console.WriteLine("title        : " + title);
            Console.WriteLine("play count   : " + playCount);
        }
    }
    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String username { get; set; }
        public SayaTubeUser(String a)
        {
            Debug.Assert(a.Length <= 100 && a.Length != null, "Karakter Username maksimal adalah 100 dan tidak boleh kosong");
            username = a;
            uploadedVideos = new List<SayaTubeVideo>(); ;
        }
        public int GetTotalVideoPlayCount()
        {
            int a = 0;
            foreach (SayaTubeVideo Data in uploadedVideos)
            {
                a = a+Data.GetPlaycount();
            }
            return a;
        }
        public void AddVideo(SayaTubeVideo video)
        {
            Debug.Assert(video != null && video.GetPlaycount() <= int.MaxValue, "Video tidak boleh kosong");
            uploadedVideos.Add(video);
        }
        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("User: "+username);
            int i = 1;
            foreach (SayaTubeVideo Data in uploadedVideos)
            {
                Console.WriteLine("Video "+ i +" Judul: " + Data.GetTitle()+", Play Count: "+ Data.GetPlaycount());
                i++;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser user1 = new SayaTubeUser("Asyraf");
            SayaTubeVideo[] video = new SayaTubeVideo[99];
            video[1] = new SayaTubeVideo("Review Film Spider-Man: NWH LTBC oleh Asyraf", 436);
            video[2] = new SayaTubeVideo("Review Film Venom: LTBC oleh Asyraf", 124);
            video[3] = new SayaTubeVideo("Review Film Eternals oleh Asyraf", 47);
            video[4] = new SayaTubeVideo("Review Film Shang-Chi oleh Asyraf", 340);
            video[5] = new SayaTubeVideo("Review Film Captain Marvel oleh Asyraf", 83);
            video[6] = new SayaTubeVideo("Review Film Avengers: Endgame oleh Asyraf", 780);
            video[7] = new SayaTubeVideo("Review Film Black Panther oleh Asyraf", 65);
            video[8] = new SayaTubeVideo("Review Film Avengers: Infinity War oleh Asyraf", 46);
            video[9] = new SayaTubeVideo("Review Film Thor: Ragnarok oleh Asyraf", 2135);
            video[10] = new SayaTubeVideo("Review Film GOTG oleh Asyraf", 205);
            int i = 1;
            while(i <= 10)
            {
                user1.AddVideo(video[i]);
                i++;
            }
            user1.PrintAllVideoPlaycount();
            Console.WriteLine("Total Play Count: "+user1.GetTotalVideoPlayCount());
            Console.ReadKey();
        }
    }
}
