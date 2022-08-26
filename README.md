# BlazorAuthApp
Authentication, in many ways, is a solved problem. .Net 6 (formerly .Net Core) provides a nice framework for web-based authentication and authorisation called ASP.Net Core Identity for this purpose.
General consensus is that it is better to use this framework than to try and "roll your own". I agree with that sentiment.
Core Identity provides code generation levers ("scaffolding") which makes it relatively easy to add authentication to an existing or new app - that is, if you use Razor pages / ASP.Net Core MVC.

If you, like me, use Blazor (Serverside) as the framework of choice, integrating Core Identity is really clunky. Scaffolded code doesn't use Blazor components but instead uses old MVC controllers and Razor views. UI of scaffolded pages is different and "sticks out".

Given MS appear to invest behind Blazor, it is odd that there is no Blazor-native scaffolding for the above yet. Microsoft have declined to put Blazor-native Core Identity code in their roadmap, which is strange.

I have recently written an app based on Blazor (Server). The web app uses Blazor as the UI framework and uses Core Identity for authentication and authorisation. The objective is to show how to manage authentication in a modern Blazor based app without needing to resort to legacy MVC approaches. I hope you find this useful.

Happy hacking!!

Anders 


