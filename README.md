# Introduction
FSharp.Blazor is a thin F# layer on top of [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) that enables you to write your Blazor views and logic in F#.

The project is inspired by and based on the great work of [Bolero](https://fsbolero.io). The main differences is that Bolero uses the Elmish programming model while FSharp.Blazor uses the same programming model as Blazor. Bolero also has a focus towards the [client-side hosting model](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0#blazor-webassembly) while FSharp.Blazor focuses on the [server-side hosting model](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-3.0#blazor-server)

# Getting started
Install [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download)

Install the project template
```
dotnet new -i FSharp.Blazor.Templates
```

Create a new F# Blazor project
```
dotnet new blazorserver -lang f# -o MyApp
```

Build and run
```
cd MyApp && dotnet run
```

# Creating a Blazor Component

You can create plain Blazor components by inheriting from the ```Component``` from thenamespace ```FSharp.Blazor```.

```fsharp
open FSharp.Blazor

type MyComponent() =
    inherit Component()

    override this.Render() =
        div [] [text "Hello, world!"]
```

To add parameters to the component, use a property with the ```Parameter``` attribute from namespace ```Microsoft.AspNetCore.Blazor```.

```fsharp
type MyComponent() =
    inherit Component()

    [<Parameter>]
    member val Who = "" with get, set

    override this.Render() =
        div [] [text (sprintf "Hello, %s!" this.Who)]
```

To instantiate a Blazor component, use the ```comp``` function. It is parameterized by the component type, and takes attributes and child nodes as arguments.

```fsharp
let myElement =
    comp<MyComponent> ["Who" => "world"] []
````

## Requiring a dependency

Any Blazor component can require a dependency. This is done by creating a mutable property with the attribute Microsoft.AspNetCore.Components.Inject:

```fsharp
open Microsoft.AspNetCore.Components
open FSharp.Blazor

type MyComponent() =
    inherit Component()

    [<Inject>]
    member val MyDependency = Unchecked.defaultof<IMyDependency> with get, set

    override this.Render() =
        // doSomethingWith this.MyDependency
```

## Providing a dependency

Dependencies are injected from the ```Startup``` class's ```ConfigureServices``` method:

```fsharp
type Startup() =

    member __.ConfigureServices(services: IServiceCollection) =
        services.AddSingleton<IMyDependency>(new MyDependency()) |> ignore
```

# Writing HTML

Create elements, attributes and event handlers in plain F#. All of the functions described here are defined in the module ```FSharp.Blazor.Html```.


## Elements

To create an HTML element, just call the function with its name. It takes two arguments: a list of attributes and a list of child elements, and returns a value of type ```Node```.

Additionally, the function ```text``` creates a text node, and ```textf``` creates a text node using printf-style formatting.

```fsharp
let myElement name =
    div [] [
        h1 [] [text "My app"]
        p [] [textf "Hello %s and welcome to my app!" name]
    ]
```

Elements that can't have children, such as ```input``` or ```br```, only take attributes as argument.

```fsharp
let myElement =
    p [] [
        text "First line of the paragraph."
        br []
        text "Second line of the paragraph."
    ]
```

To create a custom element for which there isn't a function, use ```elt```.

```fsharp
let myElement =
    elt "data-paragraph" [] [
        text "This is in a <data-paragraph> element."
    ]
```
In addition to representing an HTML node, the type ```Node``` can also represent a (possibly empty) sequence of nodes. This is done using the ```concat``` function.

```fsharp
let myElements =
    concat [
        p [] [text "First paragraph"]
        p [] [text "Second paragraph"]
    ]
```

```empty``` represents an empty sequence of nodes: it is equivalent to ```concat []```. This doesn't seem very useful at first, but it is actually important for conditional elements.

## Conditional elements

Due to the way that Blazor compares the rendered DOM when a change is applied, the returned HTML must always have the same structure: conditional elements can't be simply added. For example, the following may cause runtime errors:

```fsharp
// May fail at runtime.
let myButton (label: option<string>) =
    button [] [
        if label.IsSome then
            yield text label.Value
    ]
```

Rendering such conditional content must be done with the ```cond``` function instead.

* ```cond``` can take a boolean value, and a function to call on this value returning a Node. For example, the following is correct:

```fsharp
let myButton (label: option<string>) =
    button [] [
        cond label.IsSome <| function
            | true -> text label.Value
            | false -> empty
    ]
```
You can also see here why ```empty``` is a useful value.
* ```cond``` can also take a value whose type is an F# union, and a function that matches over the cases of this union. For example, ```option<'T>``` is an F# union, so the following is correct:

```fsharp
let myButton (label: option<string>) =
    button [] [
        cond label <| function
            | Some l -> text l
            | None -> empty
    ]
```

Here's an example with a union defined in your code:

```fsharp
/// A list of usernames, truncated to two + number of others
type UserList =
    | One of string
    | Two of string * string
    | Many of string * string * int

/// Shows one of the following, depending on the number of users:
/// * "*Alice* likes this"
/// * "*Alice* and *Bob* like this"
/// * "*Alice*, *Bob* and 12 others like this"
let showLikes (users: UserList) =
    concat [
        cond users <| function
            | One uname -> b [] [text uname]
            | Two (uname1, uname2) ->
                concat [
                    b [] [text uname1]
                    text " and "
                    b [] [text uname2]
                ]
            | Many (uname1, uname2, others) ->
                concat [
                    b [] [text uname1]
                    text ", "
                    b [] [text uname2]
                    textf " and %i others" others
                ]
        cond users <| function
            | One _ -> text " likes this."
            | _     -> text " like this."
    ]
```

## Collection elements

Similarly, rendering collections using a function such as ```List.map``` to create a list of nodes can cause runtime errors. Instead, collections of items should be rendered using the function ```forEach```.

```fsharp
let listUsers (names: string list) =
    p [] [
        text "Here are the users:"
        ul [] [
            forEach names <| fun name ->
                li [] [text name]
        ]
    ]
```

## Attributes

Attributes are available in the ```attr``` submodule.

```fsharp
let myElement =
    p [
        attr.style "color: blue;"
        attr.``class`` "paragraph"
    ] [
        text "Hello and welcome to my app!"
    ]
```

To create a custom attribute for which there isn't a function, use the ```=>``` operator.

```fsharp
let myElement =
    p ["data-kind" => "paragraph"] [
        text "Hello and welcome to my app!"
    ]
```

## Conditional attributes

Like with elements (see [Conditional elements](#conditional-elements)), naively adding conditional attributes can lead to runtime errors.

```fsharp
// May fail at runtime.
let myElement (isBlue: bool) =
    p [
        if isBlue then
            yield attr.style "color: blue;"
    ] [
        text "Hello and welcome to my app!"
    ]
```
Instead if an attribute may or may not need to be added depending on a condition, always add the attribute and give it a value of ```false``` or ```null``` when it should be omitted.

```fsharp
let myElement (isBlue: bool) =
    p [attr.style (if isBlue then "color: blue;" else null)] [
        text "Hello and welcome to my app!"
    ]
```

## Event handlers

Event handlers are available in the ```on``` submodule.

```fsharp
let myElement =
    button [on.click (fun _ -> printfn "Clicked!")] [
        text "Click me!"
    ]
```

The argument passed to the callback has type ```UIEventArgs``` from Blazor. Specific events have corresponding subtypes of ```UIEventArgs```: for example, ```on.click``` uses ```UIMouseEventArgs```.

```fsharp
let myElement =
    button [
       on.click (fun e ->
            printfn "Clicked at (%i, %i)" e.ClientX e.ClientY)
    ] [
        text "Click me!"
    ]
```

To create a custom event handler for which there isn't a function, use ```on.event```.

```fsharp
let myElement =
    button [
        on.event "customevent" (fun _ -> printfn "Custom event!")
    ] [
        text "Click me!"
    ]
```