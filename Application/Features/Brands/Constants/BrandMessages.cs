namespace Application.Features.Brands.Constants;

public class BrandMessages
{
    public const string BrandNameExist = "Brand name already exists.";
    public const string BrandNotFound = "Brand not found.";
    public const string BrandCreationFailed = "Failed to create brand.";
    public const string BrandUpdateFailed = "Failed to update brand.";
    public const string BrandDeletionFailed = "Failed to delete brand.";
    public const string InvalidBrandName = "Brand name is invalid.";
    public const string BrandNameTooShort = "Brand name must be at least 3 characters.";
    public const string BrandNameTooLong = "Brand name must not exceed 50 characters.";
    public const string BrandDescriptionTooShort = "Brand description must be at least 5 characters.";
    public const string BrandDescriptionTooLong = "Brand description must not exceed 200 characters.";
    public const string BrandInactive = "Brand is currently inactive.";
    public const string BrandAlreadyActive = "Brand is already active.";
    public const string BrandActivationFailed = "Failed to activate brand.";
    public const string BrandDeactivationFailed = "Failed to deactivate brand.";
    public const string BrandHasAssociatedProducts = "Cannot delete brand; it has associated products.";
    public const string BrandCreationSuccess = "Brand created successfully.";
    public const string BrandUpdateSuccess = "Brand updated successfully.";
    public const string BrandDeletionSuccess = "Brand deleted successfully.";
    public const string BrandAlreadyExistsInCategory = "Brand already exists in the specified category.";
    public const string BrandNotAvailableForSale = "Brand is not available for sale.";
    public const string BrandCannotBeRenamed = "Brand cannot be renamed at this time.";
}
