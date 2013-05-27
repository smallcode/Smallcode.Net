#Smallcode.Net
Fluent HttpWebClient, Http parser and Json parser.
### Usage
```csharp
string result = new Url("http://www.happay.com").CreateRequest().Get();
string result = new Url("http://www.happay.com").CreateRequest()
                                        .WithCookies(Cookie)
                                        .WithReferer(Referer)
                                        .WithUserAgent(UserAgent)
                                        .Get();
            
var data = new FormData().Set("username", "aa").Set("password", "bb");
string result = new Url("http://www.happay.com").CreateRequest().Post(data);
string result = new Url("http://www.happay.com").CreateRequest()
                                        .WithCookies(Cookie)
                                        .WithReferer(Referer)
                                        .WithUserAgent(UserAgent)
                                        .NotRedirect()
                                        .ByAjax()
                                        .Post(data);
```
