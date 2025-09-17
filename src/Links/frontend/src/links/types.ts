export type LinkListItemModel = {
  id: string;
  title: string;
  href: string;
  description: string;
  addedBy: string;
  created: string;
};

/* 
public record CreateLinkResponse
{
    // uuid 
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AddedBy { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
}
 */
