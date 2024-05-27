using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.Models.DTOs
{
	public class Article_DTO
	{
		public string ArticleHeader { get; set; }

		public string ArticleContent { get; set; }
	
        public int ReadingTime { get; set; }

        public List<Topic>? Topics { get; set; }

		public List<string>? SelectedTopics { get; set; }	
    }
}
