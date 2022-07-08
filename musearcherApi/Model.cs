namespace musearcherApi;

public class Model
{
    public class HttpRes
    {
        public HttpRes(string successful, string hot, string? title, string? author, string? songUrl, string? thumbUrl, string? releseDate)
        {
            this.IsSuccessful = successful;
            IsHot = hot;
            Title = title;
            Author = author;
            SongUrl = songUrl;
            ThumbUrl = thumbUrl;
            ReleseDate = releseDate;
        }

        private string IsSuccessful { get; set; }
        private string IsHot { get; set; }
        private string? Title { get; set; }
        private string? Author { get; set; }
        private string? SongUrl { get; set; }
        private string? ThumbUrl { get; set; }
        private string? ReleseDate { get; set; }

        public string getSuccessful()
        {
            return IsSuccessful;
        }
        
        public string getIsHot()
        {
            return IsHot;
        }
        
        public string getTitle()
        {
            return Title;
        }               
    }
}