using JetBrains.Annotations;

namespace BooknoteLogic

{
    public interface IFactory<out T>
    {
        [NotNull] T CreateProduct();
        [NotNull]string GetCreatorName();
    }
}