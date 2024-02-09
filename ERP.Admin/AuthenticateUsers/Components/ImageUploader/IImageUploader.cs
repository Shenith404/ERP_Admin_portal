
namespace UI.ImageUploader
{
    public interface IImageUploader
    {
        Task<List<string>> Post(ImageFile[] files);
    }
}