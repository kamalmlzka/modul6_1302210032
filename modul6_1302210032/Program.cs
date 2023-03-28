using System.Diagnostics;
using System.Runtime.CompilerServices;

class SayaTubeVideo
{
    private int id;
    private string title { get; set; }
    private int playCount { get; set; }

    public SayaTubeVideo(string title)
    {
        Debug.Assert(title.Length <= 200 && title != null, "Judul video memiliki panjang maksimal 200 karakter dan tidak berupa null.");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 25000000 && count > 0, "Input penambahan play count maksimal 25.000.000 per panggilan method-nya dan bukan bilangan negatif.");

        try
        {
            checked { this.playCount += count; }
        }
        catch (OverflowException err)
        {
            Console.WriteLine(err.Message);
        }
    }

    public void PrintVideoDetails(int j)
    {
        Console.WriteLine("Video " + j + " Judul: " + this.title);
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos { get; set; }
    public string username;

    public SayaTubeUser(string username)
    {
        Debug.Assert(username.Length <= 100 && username != null, "Username memiliki panjang maksimal 100 karakter dan tidak berupa null.");

        this.id = new Random().Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
        this.username = username;
    }

    public int getTotalVideoPlayCount()
    {
        return this.uploadedVideos.Count;
    }

    public void addVideo(SayaTubeVideo video)
    {
        Debug.Assert(video != null, "Video yang ditambahkan tidak berupa null dan tidak lebih dari integer maksimum");

        this.uploadedVideos.Add(video);
    }

    public void printAllVideoPlayCount()
    {
        Console.WriteLine("User: " + this.username);
        int j = 1;
        foreach (var i in uploadedVideos)
        {
            i.PrintVideoDetails(j++);
        }
    }
}

class Program
{
    public static void Main()
    {
        SayaTubeVideo vid1 = new SayaTubeVideo("Review Film Maleena oleh KamalMaulaazkaSidhqi_Praktikan");
        vid1.IncreasePlayCount(10000000);

        SayaTubeVideo vid2 = new SayaTubeVideo("Review Film Melissa P oleh KamalMaulaazkaSidhqi_Praktikan");
        vid2.IncreasePlayCount(10000000);

        SayaTubeVideo vid3 = new SayaTubeVideo("Review Film Lolita oleh KamalMaulaazkaSidhqi_Praktikan");
        vid3.IncreasePlayCount(10000000);

        SayaTubeUser user = new SayaTubeUser("Kamal Maulaazka Sidhqi");

        user.addVideo(vid1);
        user.addVideo(vid2);
        user.addVideo(vid3);

        user.printAllVideoPlayCount();
    }
}