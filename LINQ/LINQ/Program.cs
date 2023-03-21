using LINQ_Demo;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static LINQ_Demo.ListGenerators;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Extension Method
            //int x = 51;
            //Console.WriteLine(x.Reverse());//51
            #endregion

            #region Anonymous Type
            //anonyms type >>  مش تابع لكلاس معين او اوبجكت من نوع معين

            //Employee employee = new Employee() { ID = 1,Name="amjad",Salary=3000 };

            //Console.WriteLine(employee.GetType().Name);//Employee

            //var E01 = new { ID = 10, Name = "Ahmed", Salary = 20202 };
            //Console.WriteLine(E01.GetType().Name);//<>f__AnonymousType0`3  0>>first type annoums      3>>number of arttibuts in E01

            //var E02 = new { ID = 10, Name = "Ahmed"};
            //Console.WriteLine(E02.GetType().Name);//<>f__AnonymousType1`2
            //Console.WriteLine(E02.GetHashCode());//-277153598
            //E02 =E02 with { ID = 11, Name = "Ahmed" };
            //Console.WriteLine(E02.GetType().Name);//<>f__AnonymousType1`2
            //Console.WriteLine(E02.GetHashCode());//1434063662 >>not mean update
            #endregion
            #region LINQ Intro

            // LINQ: is stand for Language-Integrated Query
            // LINQ: write query in c#
            //LINQ: dql in data base( select )
            //LINQ:Depends on (Extension Methods)
            //LINQ:contain +40 Extension Methods(to the classes that implement IEnumerable interface)
            ///       Named [Query Operators] Existing at Enumerable Class and Categorized to 13 Categories
            /// Use LINQ Functions Against Data (Stored at Sequence) Regardless Data Store
            /// 1. Local Sequence : L2O, L2XML
            /// 2. Remote Sequence: L2E

            Console.WriteLine("============");
           List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            #region LINQ Syntax
            // 1. Fluent Syntax
            /// 1.1 Calling LINQ Operators as Static Methods through Enumerable

            var result = Enumerable.Where(Numbers, x => x > 5);//6 7 8
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("============");
            //1.2 Calling LINQ Operators as Extension Methods
            result = Numbers.Where(x => x >5 );
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            // 2. Query Syntax [Query Expression]: Like SQL Query Style
            // Start With from, Introducing Range Variable(N): Represents Each Element At Sequence
            // End With select Or group by >>From >>where/order by >> select or group by

            Console.WriteLine("============");
            result = from x in Numbers
                     where x > 5 
                     select x;

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            #endregion

            #region LINQ Execution

            //taype Of LINQ Execution:
            // 1. Deffered Execution (Latest Update Of Data)
            //اخر تحديث لداتا
            //All LINQ Operators Except Element, Aggregate, Casting Operators (Immediate Execution )

            Console.WriteLine("============");

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var Result=numbers.Where(x => x > 5);
            numbers.AddRange(new int[] { 9, 10, 11, 12, });
            foreach (var number in Result)
            {
                Console.WriteLine(number);//last version of data list numbers >>  6 7 8 9 10 11 12
                                           //اخر تحديث لداتا
            }

            Console.WriteLine("============");

            //2. Immediate Execution (casting operator) >>not last update to data
            List<int> numberss = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var Resultt = numberss.Where(x => x > 5).ToList();
            numberss.AddRange(new int[] { 9, 10, 11, 12, });
            foreach (var number in Resultt)
            {
                Console.WriteLine(number);//6 7 8 //because casting operator
            }
            #endregion

            #region Filtration (Restrictions) Operator - Where


            Console.WriteLine("============");

            var res = ProductList.Where(x => x.UnitsInStock == 0); // Fluent Syntax
            foreach (var number in res)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("============");
            
            res =from x in ProductList
                where x.UnitsInStock == 0 //query sentax
                select x;

            foreach (var number in res)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("============");

            res = ProductList.Where(product => product.UnitsInStock == 0 && product.Category== "Meat/Poultry"); // Fluent Syntax
            foreach (var number in res)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("============");
            res = from proudct in ProductList
                  where proudct.UnitsInStock == 0 && proudct.Category == "Meat/Poultry"
                  select proudct;
            foreach (var number in res)
            {
                Console.WriteLine(number);
            }


            #endregion

            Console.WriteLine("======IndexWhere======");
            #region Index Where
            /// Indexed Where
            /// Valid Only at Fluent Syntax. Can't be Written Using Query Expression

            // Get From The First 10 Products, The Products That Are Out Of Stock
            res = ProductList.Where((P, index) => P.UnitsInStock == 0 && index < 10);/*بتعامل م ال
                                                                                      * id 
                                                                                      * على اساس index
                                                                                      * */
                                                                                          
            foreach (var number in res)                                            
            {
                Console.WriteLine(number);
            }

            #endregion

            Console.WriteLine("======select/select many======");
            #region Transformation (Projection Operators) - Select / SelectMany

            Console.WriteLine("======select=====");
            var ress = ProductList.Select(p => p.ProductName);
            foreach (var number in ress)
            {
                Console.WriteLine(number);
            }

            ress = from p in ProductList     //query syntax
                   select p.ProductName;
            //foreach (var number in ress)
            //{
            //    Console.WriteLine(number);
            //}

            Console.WriteLine("======select many======");

            //var resss= CustomerList.Select(p => p.Orders); error because order >>list (array)
            var resss = CustomerList.SelectMany(p => p.Orders);
            foreach (var number in resss)
            {
                Console.WriteLine(number);
            }

            resss =from Customer in CustomerList//order in customer in customers list
                  from order in Customer.Orders
                  select order;
            //foreach (var number in resss)
            //{
            //    Console.WriteLine(number);
            //}


            Console.WriteLine("======select more======");

            var  reesss=ProductList.Select(p =>new {p.ProductID ,p.ProductName,p.UnitPrice });
            
            reesss = from p in ProductList
                     select new { p.ProductID, p.ProductName, p.UnitPrice };

            //reesss = ProductList.Select(p => new {Id= p.ProductID,Name=p.ProductName,Price= p.UnitPrice });
            //foreach (var number in reesss)
            //{
            //    Console.WriteLine(number);
            //}

            var re = ProductList.Select(p => new
            {
                Id = p.ProductID,
                Name = p.ProductName,
                Price = p.UnitPrice,
                Count = p.UnitsInStock,
                NewPrice = p.UnitPrice * .8m
            }).Where(p => p.Count > 10);



          var  ree = from P in ProductList
                               select new
                               {
                                   ID = P.ProductID,
                                   Name = P.ProductName,
                                   ProductCategory = P.Category,
                                   Count = P.UnitsInStock,
                                   NewPricr = P.UnitPrice * .8M
                               } into NewP
                               where NewP.Count > 10
                               select NewP;

            foreach (var number in re)
            {
                Console.WriteLine(number);
            }
            #endregion

            Console.WriteLine("====index select=====");
            #region Index Select
            // Indexed Select (Valid Only at Fluent Syntax)
            var Resulttr = ProductList.Select((P, i) => new { Index = i, ProductName = P.ProductName });
            foreach (var number in Resulttr)
            {
                Console.WriteLine(number);
            }
            #endregion


            Console.WriteLine("====Ordering Operators=====");
            #region Ordering Operators
            // Ascending Order 
            //من الصغير للكبير

            Console.WriteLine("====Ascending Order =====");
            var r = ProductList.OrderBy(P => P.UnitsInStock);
                     
            r = from P in ProductList
                orderby P.UnitsInStock
                select P;

           var rr= ProductList.OrderBy(P => P.UnitsInStock). Select(P => new { P.ProductName, P.UnitsInStock });

            rr = from P in ProductList
                orderby P.UnitsInStock
                 select new { P.ProductName, P.UnitsInStock };
            
            foreach (var number in r)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("====DescendingOrder =====");

            // DescendingOrder 
            //من كبير لصغير
            r = ProductList.OrderByDescending(P => P.UnitsInStock);


            r = from P in ProductList
                orderby P.UnitsInStock descending
                select P;
            foreach (var number in r)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("====order by multi colume =====");

            var rz = ProductList.OrderBy(P => P.UnitsInStock)
                                    .ThenBy(P => P.UnitPrice)
                                    .Select(P => new { P.ProductName, P.UnitPrice });

            rz = from P in ProductList
                     orderby P.UnitsInStock, P.UnitPrice
                     select new { P.ProductName, P.UnitPrice };

            rz = ProductList.OrderBy(P => P.UnitsInStock)    //Descending
                        .ThenByDescending(P => P.UnitPrice)
                        .Select(P => new { P.ProductName, P.UnitPrice });

            rz = from P in ProductList
                 orderby P.UnitsInStock , P.UnitPrice descending
                 select new { P.ProductName, P.UnitPrice };
            foreach (var number in rz)
            {
                Console.WriteLine(number);
            }
            #endregion

            Console.WriteLine("====Reverse Operator =====");
            #region Reverse Operator
            var s = ProductList.Select(P => P.ProductName).Reverse();
            foreach (var number in s)
            {
                Console.WriteLine(number);
            }
            #endregion

            Console.WriteLine("====max/min/sum/avg/Aggregate =====");
            #region Aggregate Operators - Immediate Execution

            var d = ProductList.Count();

            d= ProductList.Count(p=>p.UnitsInStock==0);
            Console.WriteLine($"count=${d }");
            var m = ProductList.Max(p => p.UnitPrice);
            Console.WriteLine($"max=${m}");
            m = ProductList.Min(p => p.UnitPrice);
            Console.WriteLine($"min=${m}");

           var mm = (from P in ProductList
                          where P.UnitPrice== ProductList.Min(P => P.UnitPrice)
                          select P).FirstOrDefault();
            Console.WriteLine(mm);

            var sum= ProductList.Sum(p=> p.UnitPrice);
            Console.WriteLine($"sum={sum}");

            var avg = ProductList.Average(p => p.UnitPrice);
            Console.WriteLine($"sum={avg}");

            string[] Names = { "Ahmed", "Nasr", "Eldein", "Hamdy" };
            var Rs = Names.Aggregate((str1, str2) => $"{str1} {str2}");
            Console.WriteLine(Rs);
            #endregion

            Console.WriteLine("====Casting (list/array)=====");
            #region Casting Operators - Immediate Execution

            List<Product> productsList = ProductList.Where(p => p.UnitsInStock == 0).ToList();
            foreach (var number in productsList)
            {
                Console.WriteLine(number);
            }
            Product[] PrdArr = ProductList.Where(P => P.UnitsInStock == 0).ToArray();


            Dictionary<long, Product> PrdDic = ProductList.Where(P => P.UnitsInStock == 0)
                                                            .ToDictionary(P => P.ProductID);


            Dictionary<long, string> PrdDicc = ProductList.Where(P => P.UnitsInStock == 0)
                                                            .ToDictionary(P => P.ProductID, P => P.ProductName);//key=P.ProductID  value=P.ProductName

            HashSet<Product> PrdSet = ProductList.Where(P => P.UnitsInStock == 0).ToHashSet();
            #endregion
            #endregion
        }
    }
}