using Microsoft.Extensions.Primitives;
using Store.Interfaces;

namespace Store.Middleware
{
    public class ListProductMiddleware
    {
        RequestDelegate next;
        public ListProductMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IListProductsService listProductsService)
        {
            if (context.Request.Path == "/products")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                
                var stringBuilder = new System.Text.StringBuilder("<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN\" crossorigin=\"anonymous\">");
                stringBuilder.Append("<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL\" crossorigin=\"anonymous\"></script>");
                stringBuilder.Append("<div class=\"container\"> <h3>Products</h3><table class=\"table\">");
                stringBuilder.Append("<tr> <td><h3>#   </h3></td> <td><h3>Product name   </h3></td> <td><h3>Model name   </h3></td>" +
                    " <td><h3>Category   </h3></td> <td><h3>Country </h3></td> <td><h3>Price   </h3></td>  </tr>");
                int i = 1;
                foreach (var item in listProductsService.GetProducts())
                {
                    stringBuilder.Append($"<tr><td>{i}   </td> <td>{item.Product.Name}   </td> <td>{item.Product.Model}   </td>" +
                        $"<td>{item.Category.Name}  </td> <td>{item.Producer.Country} </td> <td>{item.Product.Price}$  </td> </tr>");

                    i++;
                }

                stringBuilder.Append("</table> </div>");

                await context.Response.WriteAsync(stringBuilder.ToString());
            }
            else
            {
                await next.Invoke(context);
            }
        }

    }
}
