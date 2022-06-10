namespace musearcherApi;

public class Model
{
    class HttpRes
    {
        public HttpRes(bool successful, bool hot, string title, string author, string songUrl, string thumbUrl, DateTime releseDate)
        {
            this.successful = successful;
            if (successful == true)
            {
                Hot = hot;
                Title = title;
                Author = author;
                SongUrl = songUrl;
                ThumbUrl = thumbUrl;
                ReleseDate = releseDate;
            }
        }

        private bool successful { get; set; }
        private bool? Hot { get; set; }
        private string? Title { get; set; }
        private string? Author { get; set; }
        private string? SongUrl { get; set; }
        private string? ThumbUrl { get; set; }
        private DateTime? ReleseDate { get; set; }
        
        
    }
}