using Store.Interfaces;

namespace Store.Middleware
{
    public class AddProductMiddleware
    {
        RequestDelegate next;

        public AddProductMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAddProductService addProductService)
        {
            context.Response.ContentType = "text/html; charset=utf-8";


            if (context.Request.Path == "/addProduct")
            {
                var form = context.Request.Form;

                ProductInfo product = new ProductInfo();

                product.Product.Name = form["nameProduct"];
                product.Product.Model = form["nameModel"];
                product.Product.Price = float.Parse(form["priceProduct"]);
                product.Product.Count = int.Parse(form["countProduct"]);

                product.Producer.Name = form["nameProducer"];
                product.Producer.Country = form["countryProducer"];

                product.Category.Name = form["nameCategory"];

                addProductService.AddProduct(product);

                context.Response.Redirect("/products"); ;

            }
            else
            {
                if (context.Request.Path == "/form")
                {
                    await context.Response.SendFileAsync("html/AddProduct.html");
                }
                else
                {
                    await next.Invoke(context);
                }
            }

        }
    }
}
