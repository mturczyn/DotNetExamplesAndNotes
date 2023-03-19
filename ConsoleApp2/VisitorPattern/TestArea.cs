namespace DotNetExamplesAndNotes.ConsoleApp.VisitorPattern;

public static class TestArea
{
    public static void VisitorPaternTestArea()
    {
        // 
        Customer individualCustomer = new IndividualCustomer();
        var standardPackage = new StandardPackage();
        individualCustomer.Buy(standardPackage); // (1)
        Package package = new StandardPackage();
        individualCustomer.Buy(package); // (2)

        // Applying visitor pattern
        PackageV packageV = new AdvancedPackageV();

        IVisitor visitor = new IndividualCustomerBuyVisitor();
        packageV.Accept(visitor);// IndividualCustomer is buying Advanced-Package.

        PackageV stdPackageV = new StandardPackageV();
        visitor = new EnterpriseCustomerBuyVisitor();
        stdPackageV.Accept(visitor);// EnterpriseCustomer is buying AdvancedPackage.  

    }
}
public class Package { }
public class AdvancedPackage : Package { }
public class StandardPackage : Package { }
public class Customer
{
    public virtual void Buy(Package package)
    {
        Console.WriteLine("Customer is buying StandardPackage.");
    }
    public virtual void Buy(StandardPackage package)
    {
        Console.WriteLine("Customer is buying StandardPackage.");
    }
    public virtual void Buy(AdvancedPackage package)
    {
        Console.WriteLine("Customer is buying StandardPackage.");
    }
}

public class IndividualCustomer : Customer
{
    public override void Buy(Package package)
    {
        Console.WriteLine("IndividualCustomer is buying Package.");
    }
    public override void Buy(StandardPackage package)
    {
        Console.WriteLine("IndividualCustomer is buying StandardPackage.");
    }
    public override void Buy(AdvancedPackage package)
    {
        Console.WriteLine("IndividualCustomer is buying AdvancedPackage.");
    }
}

public class EnterpriseCustomer : Customer
{
    public override void Buy(Package package)
    {
        Console.WriteLine("EnterpriseCustomer is buying Package.");
    }
    public override void Buy(StandardPackage package)
    {
        Console.WriteLine("EnterpriseCustomer is buying StandaradPackage.");
    }
    public override void Buy(AdvancedPackage package)
    {
        Console.WriteLine("EnterpriseCustomer is buying AdvancedPackage.");
    }
}

#region with visitor pattern
public interface IVisitor
{
    void Visit(PackageV package);
    void Visit(StandardPackageV package);
    void Visit(AdvancedPackageV package);
}

public class IndividualCustomerBuyVisitor : IVisitor
{
    public void Visit(PackageV package)
    {
        Console.WriteLine("IndividualCustomer is buying Package.");
    }
    public void Visit(StandardPackageV package)
    {
        Console.WriteLine("IndividualCustomer is buying StandardPackage.");
    }
    public void Visit(AdvancedPackageV package)
    {
        Console.WriteLine("IndividualCustomer is buying AdvancedPackage.");
    }
}

public class EnterpriseCustomerBuyVisitor : IVisitor
{
    public void Visit(PackageV package)
    {
        Console.WriteLine("EnterpriseCustomer is buying Package.");
    }
    public void Visit(StandardPackageV package)
    {
        Console.WriteLine("EnterpriseCustomer is buying StandardPackage.");
    }
    public void Visit(AdvancedPackageV package)
    {
        Console.WriteLine("EnterpriseCustomer is buying AdvancedPackage.");
    }
}

public class PackageV
{
    public virtual void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class AdvancedPackageV : PackageV
{
    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class StandardPackageV : PackageV
{
    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

#endregion
