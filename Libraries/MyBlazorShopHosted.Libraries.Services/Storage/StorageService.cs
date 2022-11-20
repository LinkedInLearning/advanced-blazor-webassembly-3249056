using MyBlazorShopHosted.Libraries.Shared.Product.Models;
using MyBlazorShopHosted.Libraries.Shared.ShoppingCart.Models;

namespace MyBlazorShopHosted.Libraries.Services.Storage
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        public IList<ProductModel> Products { get; private set; }

        /// <summary>
        /// Stores the shopping cart.        
        /// </summary>
        public ShoppingCartModel ShoppingCart { get; private set; }

        /// <summary>
        ///  Constructs a storage service.
        /// </summary>
        public StorageService()
        {
            Products = new List<ProductModel>();
            ShoppingCart = new ShoppingCartModel();

            // Store a list of all the products for the online shop.
            AddProduct(new ProductModel("BLADE-MUG", "Blade Mug", "Our strong ceramic mug, with its comfortable D-shaped handle, is microwave and dishwasher safe, and available in one size: 11 oz (3.2\" diameter x 3.8\" h).", 16, "lil-monsters-mug-blade-blue.svg"));
            AddProduct(new ProductModel("BLADE-NOTEBOOK", "Blade Notebook", "Available with lined, graph, or blank pages, our lay-flat notebooks are made with curl-resistant ever-so-slightly textured smudge-proof paper that’s ideal for your ideas and creations.", 18, "lil-monsters-notebook-blade.svg"));
            AddProduct(new ProductModel("BLADE-PILLOW", "Blade Pillow", "Use as a reusable shopping bag at the farmers market, as a heavy-duty tote for business and play, and as a unique and useful fashion item.", 30, "lil-monsters-pillow-blade.svg"));
            AddProduct(new ProductModel("BLADE-TRADING-CARD", "Blade Trading Card", "Constructed of our own organic cotton weave, the pillows are stuffed with organic Kapok fibers harvested in April and May in Hawaii when the fruits mature and fall from the trees. 10 percent of each sale is donated to Hawaii's botanical gardens.", 19.99m, "lil-monsters-cards-blade-front.svg"));
            AddProduct(new ProductModel("CHARMAINE-FRAMED-ART", "Charmaine Framed Art", "Our framed artwork is hand-printed on our proprietary triple-layer organic, acid-free cotton stock, and shipped ready to hang in one of our in-house hand-made frames.", 45, "stargazers-artwork-charmaine-black.svg"));
            AddProduct(new ProductModel("CHARMAINE-TOTE-BAG", "Charmaine Framed Art", "Use as a reusable shopping bag at the farmers market, as a heavy-duty tote for business and play, and as a unique and useful fashion item.", 18.5m, "stargazers-tote-charmaine.svg"));
            AddProduct(new ProductModel("CHARMAINE-T-SHIRT", "Charmaine T-Shirt", "Our t-shirts are made from ring-spun, long-staple organic cotton that's ethically sourced from member farms of local organic cotton cooperatives. Original artwork is screen-printed using PVC- and phthalate-free inks. Features crew-neck styling, shoulder-to-shoulder taping, and a buttery soft feel. Machine-wash warm, tumble-dry low.", 19.99m, "stargazers-tshirt-charmaine-black.svg"));
            AddProduct(new ProductModel("CHARMAINE-TRADING-CARD", "Charmaine Trading Card", "Our deluxe, limited-edition trading cards are printed on our proprietary, textured, triple-layer organic stock. After printing, all cards are silk laminated to better preserve the cards and to best showcase its character and copy. In addition, each of our cards is encased in an acid-free rigid card sleeve to further protect it from UV rays, moisture, and handling.", 19.99m, "stargazers-cards-charmaine-front.svg"));
            AddProduct(new ProductModel("DELORES-T-SHIRT", "Delores T-Shirt", "Our t-shirts are made from ring-spun, long-staple organic cotton that's ethically sourced from member farms of local organic cotton cooperatives. Original artwork is screen-printed using PVC- and phthalate-free inks. Features crew-neck styling, shoulder-to-shoulder taping, and a buttery soft feel. Machine-wash warm, tumble-dry low.", 26, "binaryville-tshirt-dolores-black.svg"));
            AddProduct(new ProductModel("DELORES-TRADING-CARD", "Delores Trading Card", "Our deluxe, limited-edition trading cards are printed on our proprietary, textured, triple-layer organic stock. After printing, all cards are silk laminated to better preserve the cards and to best showcase its character and copy. In addition, each of our cards is encased in an acid-free rigid card sleeve to further protect it from UV rays, moisture, and handling.", 19.99m, "binaryville-cards-dolores-front.svg"));
            AddProduct(new ProductModel("DELORES-HAT", "Delores Hat", "Cheer the team on in style with our unstructured, low crown, six-panel baseball cap made of 100% organic cotton twill. Featuring our original Big Star Collectibles artwork, screen-printed with PVC- and phthalate-free inks. Complete with matching sewn ventilation eyelets, and adjustable fabric closure.", 29, "binaryville-hat-dolores-black.svg"));
            AddProduct(new ProductModel("DELORES-APRON", "Delores Apron", "Everyon's a chef in our eco-friendly apron made from 55% organic cotton and 45% recycled polyester. Showcasing your favorite Big Star Collectibles design, the apron is screen-printed in PVC- and phthalate-free inks. Apron measures 24 inches wide by 30 inches long and is easily adjustable around the neck and waist with one continuous strap. Machine-wash warm, tumble-dry low.", 24, "binaryville-apron-dolores-white.svg"));

        }

        /// <summary>
        /// Adds a product to the storage.
        /// </summary>
        /// <param name="productModel">The <see cref="ProductModel"/> type to be added.</param>
        private void AddProduct(ProductModel productModel)
        {
            if (!Products.Any(p => p.Sku == productModel.Sku))
            {
                Products.Add(productModel);
            }
        }
    }
}
