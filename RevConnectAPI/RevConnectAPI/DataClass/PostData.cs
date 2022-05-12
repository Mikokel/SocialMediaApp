namespace RevConnectAPI.DataClass
{
    public class PostData
    {
        private int _postID;
        private string _body;
        private DateTime _date;
        private string _image;
        private int _userID;

        public PostData(int postID, string body, DateTime date, string image, int userID)
        {
            _postID = postID;
            _body = body;
            _date = date;
            _image = image;
            _userID = userID;
        }

        public int postID { get; set; }
        public string body { get; set; }
        
        public DateTime date { get; set; }
        public string? image { get; set; }
        public int userID { get; set; }



        //// Constructor
        //public PostData() { }
        //public PostData(int postID, string body, DateTime date, string? image, int userID)
        //{
        //    this.postID = postID;
        //    this.body = body;
        //    this.date = date;
        //    this.image = image;
        //    this.userID = userID;

        //}


    }
}
