#Smallcode.Net
Fluent HttpWebClient, Http parser and Json parser.
### Usage
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
