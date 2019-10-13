namespace FSharp.Blazor

open System
open Microsoft.AspNetCore.Components

/// HTML attribute or Blazor component parameter.
type Attr =
    | Attr of string * obj
    | Attrs of list<Attr>
    | Key of obj
    | ExplicitAttr of (Rendering.RenderTreeBuilder -> int -> obj -> unit)
    | Ref of Action<ElementReference>

/// HTML fragment.
type Node =
    /// An empty HTML fragment.
    | Empty
    /// A concatenation of several HTML fragments.
    | Concat of list<Node>
    /// A single HTML element.
    | Elt of name: string * attrs: list<Attr> * children: list<Node>
    /// A single HTML text node.
    | Text of text: string
    /// A raw HTML fragment.
    | RawHtml of html: string
    /// A single Blazor component.
    | Component of Type * attrs: list<Attr> * children: list<Node>
    /// A conditional "if" component.
    | Cond of bool * Node
    /// A conditional "match" component.
    | Match of unionType: Type * value: obj * node: Node
    /// A list of similarly structured fragments.
    | ForEach of list<Node>
    | ComponentInstance of RenderFragment

    static member BlazorComponent<'T when 'T :> IComponent>(attrs, children) =
        Node.Component(typeof<'T>, attrs, children)

