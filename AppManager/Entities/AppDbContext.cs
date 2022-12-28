using Microsoft.EntityFrameworkCore;

namespace AppManager.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }
        public DbSet<FileManageEntity> FileManageEntities { get; set; }
        public DbSet<ProductImageEntity> ProductImageEntities { get; set; }
        public DbSet<CategoryImageEntity> CategoryImageEntities { get; set; }
        public DbSet<AccountEntity> AccountEntities { get; set; }
        public DbSet<AccountAvatarEntity> AccountAvatarEntities { get; set; }
        public DbSet<BannerEntity> BannerEntities { get; set; }
        public DbSet<BannerImageEntity> BannerImageEntities { get; set; }
        public DbSet<BlogEntity> BlogEntities { get; set; }
        public DbSet<BlogCategoryEntity> BlogCategoryEntities { get; set; }
        public DbSet<BlogTagsEntity> BlogTagsEntities { get; set; }
        public DbSet<DiscountEntity> DiscountEntities { get; set; }
        public DbSet<DiscountCodeEntity> DiscountCodeEntities { get; set; }
        public DbSet<UsedDiscountCodeEntity> UsedDiscountCodeEntities { get; set; }
        public DbSet<CartEntity> CartEntities { get; set; }
        public DbSet<TypedDiscountEntity> TypedDiscountEntities{ get; set; }
        public DbSet<SalesReceiptEntity> SalesReceiptEntities { get; set; }
        public DbSet<SalesReceiptDetailEntity> SalesReceiptDetailEntities { get; set; }
        public DbSet<ContactMessageEntity> ContactMessageEntities { get; set; }
    }
}
