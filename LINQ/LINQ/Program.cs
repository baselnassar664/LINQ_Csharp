using LINQ.Data;
using LINQ_Demo;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
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
            // End With select Or group by >>From >>where/order by >>then by>> select or group by

            Console.WriteLine("============");
            result = from x in Numbers
                     where x > 5 
                     select x;

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            #endregion

            Console.WriteLine("======LINQ Execution======");
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

            Console.WriteLine("======Enumerable=====");
            #region Enumerable  Generator Operators
            // The only way to call them is as static methods from Enumrable Class
            //var resultt = Enumerable.Range(10, 100);
            var resultt = Enumerable.Repeat(10, 5);
            //var resultt = Enumerable.Empty<Product>(); // new List<Product>()
            foreach (var item in resultt)
                Console.Write($"{item} ");
            #endregion
            Console.WriteLine("\n======Any=====");
            #region  any
            int[] n = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var any=n.Any(n => n > 5);
            Console.WriteLine(any);//true 6 and 7 >5

            var an = Dataa.pets.Any(n => n.Name == "Bruce");//false
            Console.WriteLine(an);

            var ann = Dataa.pets.Any(p => p.PetType == PetType.Fish);//true

            Console.WriteLine(ann);

            var annn = Dataa.pets.Any(p => p.Name.Length > 6 && p.Id % 2 == 0);//true   new Pet(2, "Anthony", PetType.Cat, 2f),



            Console.WriteLine(annn);
            #endregion

            Console.WriteLine("===========contain=========");
            #region containS

            int[] nu = new[] { 10, 1, 4, 17, 122 };
            var contains10 = numbers.Contains(10);
            Console.WriteLine($"contains10: {contains10}");

            var containsAnthony = Dataa.pets.Contains(new Pet(2, "Anthony", PetType.Cat, 2f));
            Console.WriteLine($"containsAnthony: {containsAnthony}");

           

            #endregion contain

            Console.WriteLine("======all=========");
            #region ALL
            var areAllNumbersLargerThanZero = numbers.All(n => n > 0);
            Console.WriteLine($"areAllNumbersLargerThanZero: {areAllNumbersLargerThanZero}");//true

            //سؤال حلو
            var doAllPetsHaveNonEmptyName = Dataa.pets.All(p => !string.IsNullOrEmpty(p.Name));
            Console.WriteLine($"doAllPetsHaveNonEmptyName: {doAllPetsHaveNonEmptyName}");

            var areAllPetsCats = Dataa.pets.All(pet => pet.PetType == PetType.Cat);
            Console.WriteLine($"areAllPetsCats: {areAllPetsCats}");

            #endregion

            #region Filtration (Restrictions) Operator - Where


            Console.WriteLine("======(Restrictions) Operator - Where======");

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

            //سؤال حلو
            //Returns digits whose name is shorter than their value.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //five = 4 char <5
            //six = 3 char <6
            //seven = 5 char <7
            //eight = 8 char <8
            //nine = 9 char <9
            //var resss = Arr.Where((valueArr, index) => valueArr.Length < index);
            //foreach (var number in resss)
            //{
            //    Console.WriteLine(number);
            //}
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

            //سؤال حلو
            // Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var resa = from aa in numbersA
                      from b in numbersB
                      where aa < b
                      select new { aa, b };

            foreach (var x in resa)
            {
                Console.WriteLine($"{x.aa} is less than  {x.b}");
                /*
                0 is less than  1
                0 is less than  3
                0 is less than  5
                0 is less than  7
                0 is less than  8
                2 is less than  5
                2 is less than  7
                2 is less than  8
                4 is less than  5
                4 is less than  7
                4 is less than  8
                5 is less than  7
                5 is less than  8
                6 is less than  7
                6 is less than  8
                */

            }
            //Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var resb = words.Select(x => new { Original = x, Upper = x.ToUpper(), Lower = x.ToLower() });
            foreach (var number in resb)
            {
                Console.WriteLine(number);
            }
            #endregion

            Console.WriteLine("====index select=====");
            #region Index Select
            // Indexed Select (Valid Only at Fluent Syntax)
            var Resulttr = ProductList.Select((P, index) => new { Index = index, ProductName = P.ProductName });
            foreach (var number in Resulttr)
            {
                Console.WriteLine(number);
            }


            //سؤال حلو
            int[] Arrz = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine("Number: In-place?");
            foreach (var (number, index) in Arrz.Select((number, index) => (number, index)))
            {
                bool isMatch = number == index;
                Console.WriteLine($"{number}: {isMatch}");/*
                                                           * 5: False
                                                           * 4: False
                                                           * 1: False
                                                           * 3: True
                                                           * 9: False
                                                           * 8: False
                                                           * 6: True
                                                           * 7: True
                                                           * 2: False
                                                           * 0: False
                                                           */

            }
            #endregion


            Console.WriteLine("====Ordering Operators  OrderBy=====");
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


            Console.WriteLine("====First/last/Default/ElementAt/single/skip=====");
            #region Element Operators - Immediate Execution
            //// Valid Only with Fluent Syntax not in query syntax
           
            var l=ProductList.First();
            Console.WriteLine($"first={l}");
            l = ProductList.Last();
            Console.WriteLine($"last={l}");

            List<Product> products = new List<Product>();
            /* var a = products.First();*///error not found first proudct(null)
            var a = products.FirstOrDefault();//defult =null
            a = products.LastOrDefault();//defult =null
            Console.WriteLine(a);

            a = ProductList.First(p =>p.UnitsInStock==0);
            a = ProductList.Last(p =>p.UnitsInStock==0);
            a = ProductList.FirstOrDefault(p => p.UnitsInStock == 200);//not found UnitsInStock == 200 use  FirstOrDefault more safety
            Console.WriteLine(a);

            var z = ProductList.ElementAt(20);//elemnt index 20
             z = ProductList.ElementAtOrDefault(20);//elemnt index 20
            Console.WriteLine(z);


            //3 Retrieve the second number greater than 5 
            int[] Ar = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //8 second number greater than 5 
            //use skip
            var q = Ar.Where(x => x > 5).Skip(1).FirstOrDefault();
            Console.WriteLine(q);


            /*  var xx = products.Single();*/ //error //beacause products not contain one elemnt
                                              //single>>يعني هل يحتوي ع عنصر واحد 
                                              // Throw Exception becuse  List<Product> is empty
                                              //// If Sequence Conatins Just Only One Element, Will Return it
                                              //// Else Will Throw Exception (Sequence is Empty or Containts More than One Element
            ///
            var xx = ProductList.Single(p=>p.ProductID==10);//يعني هل يوجد فقط واحد 
                                                            //proudct id=10
                                                            // ولو وجدو رجعو

             xx = ProductList.SingleOrDefault(p => p.ProductID == 200);//هان لو مالقاش الايدي 200 حيرجع
                                                                       //defult value =null
            Console.WriteLine(xx);


            //// Hyprid Syntax: (Query Expression).FluentSyntax
            var R = (from P in ProductList
                     where P.UnitPrice > 300
                     select new { P.ProductName, P.Category }).FirstOrDefault();
            Console.WriteLine(xx);
            #endregion


            Console.WriteLine("====count/max/min/sum/avg/Aggregate =====");
            #region Aggregate Operators - Immediate Execution

            var d = ProductList.Count();

            d= ProductList.Count(p=>p.UnitsInStock==0);
            Console.WriteLine($"count=${d }");

            var countOfDogs = Dataa.pets.Count(pet => pet.PetType == PetType.Dog);
            Console.WriteLine($"countOfDogs: {countOfDogs}");//3

            var countOfPetsNamedBruce = Dataa.pets.Count(pet => pet.Name == "Bruce");
            Console.WriteLine($"countOfPetsNamedBruce: {countOfPetsNamedBruce}");

            var countOfAllSmallDogs = Dataa.pets.Count(pet =>
          pet.PetType == PetType.Dog &&
          pet.Weight < 10);
            Console.WriteLine($"countOfAllSmallDogs: {countOfAllSmallDogs}");
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

            // Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arrr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            List<string> list = Arrr.Where(x => x[1] == 'i').Select(x => new string(x.Reverse().ToArray())).ToList();
            foreach (var number in list)
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

            Console.WriteLine("union/concat/Intersect/Distinct/Except");
            #region Set Operators union/concat/Intersect/Distinct/Except  (no quires syntax)

            List<int> ints = new List<int>() { 1, 2, 3, 4 };
            List<int> intss = new List<int>() { 1, 2, 3, 4, 5, 6 };

                         
        
            var zz = ints.Union(intss);     // union Remove Duplicates
                                            //// Remove Duplicates
                                            //بدمج مع عدم التكرار 
                                            //value
            foreach (var product in zz)
                Console.WriteLine(product);
            Console.WriteLine("======");
           
            zz= ints.Concat(intss);/*concat=union all in data base
                                    * دمج كل القيم مع تكرار القيم 
                                    *value 
                                    */
            foreach (var product in zz)
                Console.WriteLine(product);

            Console.WriteLine("======");
            zz = zz.Distinct();//Distinct // //// Remove Duplicates
            foreach (var product in zz)
                Console.WriteLine(product);
            Console.WriteLine("======");
            
            zz = ints.Intersect(intss);// بتجيب القيم المتكررةIntersect 
            foreach (var product in zz)
                Console.WriteLine(product);

            Console.WriteLine("======");
            zz = ints.Except(intss);//excpect
                                      //بتجيب حجات الي موجودة 
                                      //in ints
                                      //ومش موجودة في
                                      //intss
            foreach (var product in zz)
                Console.WriteLine(product);
            #endregion

            Console.WriteLine("======(Boolean Value)any/all/SequenceEqual=======");
            #region Quantifiers Operators => Return Boolean Value   (no quires syntax)
            Console.WriteLine(ProductList.Any());//true
            //ProductList.Any() >>يعني هل يوجد فيها اي 
                              //item
            Console.WriteLine(ProductList.Any(product => product.UnitsInStock == 500));//false

            Console.WriteLine(ProductList.All(product => product.ProductID > 0));

            Console.WriteLine(ints.SequenceEqual(intss));//false
            /*
             * any>>هل تحتوي 
             * all>>هل كل القيم
             * SequenceEqual>>هل القيم متساوية بين الاثنين
             * */
            #endregion
            Console.WriteLine("===========take/skip============");
            #region Partitioning Operators  (no quires syntax)
            // Get the first 3 products that are out of stock

            //var result = ProductList.Where(product => product.UnitsInStock == 0).Take(3);
            //// Get the last 3 products that are out of stock
            //result = ProductList.Where(product => product.UnitsInStock == 0).TakeLast(3);

            //// Get all but the first 2 products that are out of stock
            //result = ProductList.Where(product => product.UnitsInStock == 0).Skip(2);

            //// Get all but the last 2 products that are out of stock
            //result = ProductList.Where(product => product.UnitsInStock == 0).SkipLast(2);

            int[] numberrs = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
          
            var resaa = numberrs.TakeWhile((numbers, index) => numbers > index);

            //5> index 0
            //4>>index 1
            //1<<index 2 >>خلص بقف هان
            //take while>>حيضل يوخد الارقام طول الشرط بتحقق واول مايتحققش بقف ماباخد الرقم
            foreach (var item in resaa)
                Console.WriteLine(item);

            #endregion

            Console.WriteLine("======group by=======");
            #region Grouping Operator
            //var result = ProductList.Where(product => product.UnitsInStock > 0)
            //                .GroupBy(product => product.Category)
            //                .Where(ProductGroup => ProductGroup.Count() > 10)
            //                .OrderByDescending(ProductGroup => ProductGroup.Count())
            //                .Select(ProductGroup => new { Category = ProductGroup.Key, Count = ProductGroup.Count() } );


            //result = from product in ProductList
            //         where product.UnitsInStock > 0
            //         group product by product.Category
            //         into ProductGroup
            //         where ProductGroup.Count() > 10
            //         orderby ProductGroup.Count() descending
            //         select new { Category = ProductGroup.Key, Count = ProductGroup.Count() };

            //foreach (var group in result)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var item in group)
            //        Console.WriteLine($"=== {item}");

            //    Console.WriteLine("=========================================================");
            //}

            //foreach ( var group in result )
            //{
            //    Console.WriteLine(group);
            //}

            var bc = ProductList  
                 .Where(p => p.UnitsInStock > 0)
                 .GroupBy(p => p.Category);//العناصر الي الهم نفس اسم
                                           //category
             //query syntax
            bc = from p in ProductList
                 where p.UnitsInStock > 0
                 group p by p.Category;

            foreach (var item in bc)
            {
                 Console.WriteLine(item.Key);//key >> name of Category
                foreach (var item2 in item)
                  Console.WriteLine(item2);//item2 >>العناصر الي الهم نفس اسم 
                                           //Category

                Console.WriteLine("==========");
            }

            Console.WriteLine("=========");

            var bcc = ProductList
                      .Where(p => p.UnitsInStock > 0)
                      .GroupBy(p => p.Category)
                      .Where(p => p.Count() > 10)//عدد العناصر الي رجعالي الي الهم نفس اسم الكاتجوري اكبر من 10
                      .OrderByDescending(p => p.Count())//رتبهم من كبير لصغير 
                      .Select(p => new { category = p.Key, count = p.Count() });// اعرض اسم الكاتجوري وعدد العناصر

            bcc = from p in ProductList
                  where p.UnitsInStock > 0
                  group p by p.Category
                  into p
                  where p.Count() > 10
                  orderby p.Count() descending
                  select new { category = p.Key, count = p.Count() };

            foreach (var item in bcc)
                Console.WriteLine(item);

            #endregion

            Console.WriteLine("======Let / Into========");
            #region Let / Into
            List<string> Namess = new List<string> { "Ahmed", "Ali", "Sally", "Mohamed", "Mohsen" };

            ////var result = from name in Names
            ////             select Regex.Replace(name, "[aeoiuAEOIU]", String.Empty)
            ////             into newName
            ////             where newName.Length >= 3
            ////             select newName;

            //var result = from name in Names
            //             let newName = Regex.Replace(name, "[aeoiuAEOIU]", String.Empty)
            //             where newName.Length >= 3
            //             select newName;

            //var DiscountProducts = ProductList.Select(P => new
            //{
            //    ID = P.ProductID,
            //    Name = P.ProductName,
            //    ProductCategory = P.Category,
            //    Count = P.UnitsInStock,
            //    NewPrice = P.UnitPrice * .8M
            //}).Where(P => P.Count > 10);

            //DiscountProducts = from P in ProductList
            //                   let NewP = new
            //                   {
            //                       ID = P.ProductID,
            //                       Name = P.ProductName,
            //                       ProductCategory = P.Category,
            //                       Count = P.UnitsInStock,
            //                       NewPrice = P.UnitPrice * .8M
            //                   } 
            //                   where NewP.Count > 10
            //                   select NewP;

            //foreach (var name in result)
            //    Console.WriteLine(name);

            var lh=from nn in  Namess
                   select Regex.Replace(nn, "[aeoiuAEOIU]", String.Empty)
                   into Nn
                   where Nn.Length > 3
                   select Nn;

            lh=from nn in Namess
               let name= Regex.Replace(nn, "[aeoiuAEOIU]", String.Empty)
               where name.Length >= 3
               select name;
            foreach (var item in lh)
                Console.WriteLine(item);
            #endregion

                   #endregion
        }
    }
}
