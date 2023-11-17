namespace P09BlazorApp.Models
{
	public class AddShoeDto
	{
		public double ShoeSize { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }

		public AddShoeDto(double size, string description, string name) { 
			this.Description = description;
			this.Name = name;
			this.ShoeSize = size;
		}
	}
}
