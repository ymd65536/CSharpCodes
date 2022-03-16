// NameValueColllection の使い方
using System.Collections.Specialized;
using System.Text.RegularExpressions;

var query = new NameValueCollection();

string html = "<input type=\"text\" name=\"test\" value=\"0\">";
Regex rgx = new(@"<input[^>]+>");

foreach (Match e in rgx.Matches(html))
{
  Regex TypeAttrRgx = new(@"type=""?([^\s""]+)""?");
  Match TypeAttrMa = TypeAttrRgx.Match(e.ToString());
  string type = TypeAttrMa.Groups[1].Value.ToString();


  Regex NameAttrRgx = new(@"name=""?([^\s""]+)""?");
  Match NameAttrMa = NameAttrRgx.Match(e.ToString());
  string name = NameAttrMa.Groups[1].Value.ToString();

  Regex ValueAttrRgx = new(@"value=""([^""]+)""");
  Match ValueAttrMa = ValueAttrRgx.Match(e.ToString());
  string value = ValueAttrMa.Groups[1].Value.ToString();
  if (type == "text" || type == "hidden")
  {
    query.Add(name, value);
  }
}

Console.WriteLine(query.Count.ToString());