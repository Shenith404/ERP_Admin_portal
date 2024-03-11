namespace ERP.UI.Components.ImageUploader
{
    public interface IImageUploader
    {
        Task<List<string>> Post(ImageFile[] files);
    }
}