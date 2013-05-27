#Smallcode.Net
Fluent HttpWebClient, Http parser and Json parser.

### Usage

#### HttpWebClient

```csharp
string result = new Url("http://www.xxx.com").CreateRequest().Get();
string result = new Url("http://www.xxx.com").CreateRequest()
                                        .WithCookies(Cookie)
                                        .WithReferer(Referer)
                                        .WithUserAgent(UserAgent)
                                        .Get();
            
var data = new FormData().Set("username", "foo").Set("password", "bar");
string result = new Url("http://www.xxx.com").CreateRequest().Post(data);
string result = new Url("http://www.xxx.com").CreateRequest()
                                        .WithCookies(Cookie)
                                        .WithReferer(Referer)
                                        .WithUserAgent(UserAgent)
                                        .NotRedirect()
                                        .ByAjax()
                                        .Post(data);
```

#### Http parser 

```csharp
//FindElement
var html = Html.Parse("<div class=\"class\" id=\"id\" name=\"name\"><a href=\"http://www.test.com\">click me</a></div><div class=\"class other\" id=\"other\"><a href=\"http://www.test1.com\">click me</a></div>");
var name = html.FindElement(By.TagName("div")).GetAttribute("name"); // should be : name
var name = html.FindElement(By.TagName("TagName")).GetAttribute("name"); 
var name = html.FindElement(By.ClassName("class")).GetAttribute("name"); 
var name = html.FindElement(By.XPath("//div")).GetAttribute("name"); 
var href = html.FindElement(By.LinkText("click me")).GetAttribute("href"); //should be : http://www.test.com
var href = html.FindElement(By.PartialLinkText("click")).GetAttribute("href"); //should be : http://www.test.com

//FindElements
var elements = html.FindElements(By.TagName("div")); 
```

#### Json parser 

```csharp
```
