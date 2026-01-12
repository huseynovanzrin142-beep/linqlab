namespace LINQTutorial;

public class MenuItem
{
    public int Key { get; }
    public string? Text { get; }

    public Action? Action { get; }

    public List<MenuItem> SubItems { get; }

    public bool HasSubItem => SubItems != null && SubItems.Count > 0;

    public MenuItem(int key, string? text, Action? action = null, List<MenuItem>? subItems = null)
    {
        Key = key;
        Text = text;
        Action = action;           
        SubItems = subItems ?? new List<MenuItem>();
    }
}