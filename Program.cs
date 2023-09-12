using projetoWEB_SA3.classes;

namespace projetoWEB_SA3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        Customer c1 = new Customer() {id=1 , name="Frederico"};

        Bank dba = new Bank();
        dba.loadData();

        app.MapGet("/", () => "Hello World!");

        //app.MapGet("/products" , () => "products!!!!");
        app.MapGet("/products", (HttpContext context) => 
            {
                context.Response.Redirect("products.html", false);
            }
        );

        app.MapGet("/clients" , (string nameParm, string email) => $"Customer's name: { nameParm }, e-mail: { email }.");

        app.MapGet("/customersupdate" , (int id, string nameRead) =>
            {
                c1.id = id;
                c1.name = nameRead;
                return "Information updated";
            });
        
        app.MapGet("/customers", () => $"The number { c1.id } ID's customer name is: { c1.name }.");

        app.MapGet("/api", (Func<object>) ( () => 
            
                new {
                    id = c1.id , name = c1.name
                }
            ));

        app.MapGet("/htmlTest", async (HttpContext context) => 
            {
                string page = "<h1> Supliers </h1>";
                page = page + $"<h3> ID: {c1.id} Name: { c1.name }</h3>";

                await context.Response.WriteAsync(page);
                //context1.Response.WriteAsync("<h1> Supliers </h1>");
            });

        app.MapGet("/bank", () => {

            var listValues = "";
            List<Customer> auxList = dba.getList();
            foreach(Customer aux in auxList){

                listValues = listValues + $"<b>ID:</b> {aux.id} <b>Name:</b> {aux.name}\n";
            }
            return listValues;
            }
        );

        app.Run(async (HttpContext context) => {
            await context.Response.WriteAsync("Page not found");
        });

        app.UseStaticFiles();
        app.Run();
    }
}
