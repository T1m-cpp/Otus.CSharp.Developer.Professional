using Reflection;
using Reflection.TestClasses;

var f = new F();
var tester = new PerformanceTester<F>(F.Get());
tester.RunTest(1_000);
tester.RunTest(10_000);
tester.RunTest(1_000_000);