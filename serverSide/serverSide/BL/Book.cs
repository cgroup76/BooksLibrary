namespace serverSide.BL
{
    public class Book
    {
        int id;
        string title;
        string subTitle;
        bool isEbook;
        bool isActive;
        bool isAvailable;
        double price;
        string category;
        string smallThumbnail;
        string thumbnail;
        int numOfPages;
        string description;
        string previewLink;
        string publishDate;
        string authorName;
        Random randomPrice;  // generate a random price for each book
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string SubTitle { get => subTitle; set => subTitle = value; }
        public bool IsEbook { get => isEbook; set => isEbook = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public string SmallThumbnail { get => smallThumbnail; set => smallThumbnail = value; }
        public string Thumbnail { get => thumbnail; set => thumbnail = value; }
        public int NumOfPages { get => numOfPages; set => numOfPages = value; }
        public string Description { get => description; set => description = value; }
        public string PreviewLink { get => previewLink; set => previewLink = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string AuthorName { get => authorName; set => authorName = value; }

        public Book(int id, string title, string subTitle, bool isEbook, bool isActive, bool isAvailable, float price, string category,
            string smallThumbnail, string thumbnail, int numOfPages, string description, string previewLink, string publishDate, string author)
        {
            this.id = id;
            this.title = title;
            this.subTitle = subTitle;
            this.isEbook = isEbook;
            this.isActive = isActive;
            this.isAvailable = isAvailable;
            this.price = randomPrice.NextInt64(50, 301) + randomPrice.NextDouble();  // generate a random decimal price between 50 to 300 
            this.category = category; 
            this.smallThumbnail = smallThumbnail;
            this.thumbnail = thumbnail;
            this.numOfPages = numOfPages;
            this.description = description;
            this.previewLink = previewLink;
            this.publishDate = publishDate;
            this.authorName = author;
        }
    }

}

