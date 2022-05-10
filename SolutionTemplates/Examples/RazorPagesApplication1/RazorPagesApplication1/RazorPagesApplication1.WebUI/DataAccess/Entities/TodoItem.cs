// ---------------------------------------------------------------------------------------------------------------------
// Solution:  RazorPagesApplication1
// File:      TodoItem.cs
// ---------------------------------------------------------------------------------------------------------------------

namespace RazorPagesApplication1.WebUI.DataAccess.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }
}