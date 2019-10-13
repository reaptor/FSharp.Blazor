
module rec FSharp.Blazor.Html

#nowarn "10001" // `event` calls `eventInline` which has custom warning

open System
open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Components.Web

/// Create an HTML text node.
let text str = Text str

/// Create an HTML text node using formatting.
let textf format = Printf.kprintf text format

/// Create an HTML element.
let elt name attrs children = Node.Elt(name, attrs, children)

/// Create an empty HTML fragment.
let empty = Empty

/// Concatenate HTML fragments.
let concat nodes = Concat nodes

/// Create an HTML attribute.
let (=>) name value = Attr(name, box value)

/// Create a conditional fragment. `matching` must be either a boolean or an F# union.
/// If it's a union, `mkNode` must only match on the case.
let cond<'T> (matching: 'T) (mkNode: 'T -> Node) =
    if typeof<'T> = typeof<bool> then
        Node.Cond(unbox<bool> matching, mkNode matching)
    else
        Node.Match(typeof<'T>, matching, mkNode matching)

/// Create a fragment that concatenates nodes for each item in a sequence.
let forEach<'T> (items: seq<'T>) (mkNode: 'T -> Node) =
    Node.ForEach [for n in items -> mkNode n]

/// Create a fragment from a Blazor component.
let comp<'T when 'T :> IComponent> attrs children =
    Node.BlazorComponent<'T>(attrs, children)

/// Create a fragment from a Blazor component.
let compInstance renderFragment =
    Node.ComponentInstance(renderFragment)

/// Create a navigation link which toggles its `active` class
/// based on whether the current URI matches its `href`.
let navLink (``match``: Routing.NavLinkMatch) attrs children =
    comp<Routing.NavLink> (("Match" => ``match``) :: attrs) children

// BEGIN TAGS
/// Create an HTML `<a>` element.
let a (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "a" attrs children

/// Create an HTML `<abbr>` element.
let abbr (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "abbr" attrs children

/// Create an HTML `<acronym>` element.
let acronym (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "acronym" attrs children

/// Create an HTML `<address>` element.
let address (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "address" attrs children

/// Create an HTML `<applet>` element.
let applet (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "applet" attrs children

/// Create an HTML `<area>` element.
let area (attrs: list<Attr>) : Node =
    elt "area" attrs []

/// Create an HTML `<article>` element.
let article (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "article" attrs children

/// Create an HTML `<aside>` element.
let aside (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "aside" attrs children

/// Create an HTML `<audio>` element.
let audio (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "audio" attrs children

/// Create an HTML `<b>` element.
let b (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "b" attrs children

/// Create an HTML `<base>` element.
let ``base`` (attrs: list<Attr>) : Node =
    elt "base" attrs []

/// Create an HTML `<basefont>` element.
let basefont (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "basefont" attrs children

/// Create an HTML `<bdi>` element.
let bdi (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "bdi" attrs children

/// Create an HTML `<bdo>` element.
let bdo (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "bdo" attrs children

/// Create an HTML `<big>` element.
let big (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "big" attrs children

/// Create an HTML `<blockquote>` element.
let blockquote (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "blockquote" attrs children

/// Create an HTML `<body>` element.
let body (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "body" attrs children

/// Create an HTML `<br>` element.
let br (attrs: list<Attr>) : Node =
    elt "br" attrs []

/// Create an HTML `<button>` element.
let button (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "button" attrs children

/// Create an HTML `<canvas>` element.
let canvas (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "canvas" attrs children

/// Create an HTML `<caption>` element.
let caption (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "caption" attrs children

/// Create an HTML `<center>` element.
let center (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "center" attrs children

/// Create an HTML `<cite>` element.
let cite (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "cite" attrs children

/// Create an HTML `<code>` element.
let code (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "code" attrs children

/// Create an HTML `<col>` element.
let col (attrs: list<Attr>) : Node =
    elt "col" attrs []

/// Create an HTML `<colgroup>` element.
let colgroup (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "colgroup" attrs children

/// Create an HTML `<content>` element.
let content (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "content" attrs children

/// Create an HTML `<data>` element.
let data (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "data" attrs children

/// Create an HTML `<datalist>` element.
let datalist (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "datalist" attrs children

/// Create an HTML `<dd>` element.
let dd (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dd" attrs children

/// Create an HTML `<del>` element.
let del (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "del" attrs children

/// Create an HTML `<details>` element.
let details (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "details" attrs children

/// Create an HTML `<dfn>` element.
let dfn (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dfn" attrs children

/// Create an HTML `<dialog>` element.
let dialog (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dialog" attrs children

/// Create an HTML `<dir>` element.
let dir (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dir" attrs children

/// Create an HTML `<div>` element.
let div (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "div" attrs children

/// Create an HTML `<dl>` element.
let dl (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dl" attrs children

/// Create an HTML `<dt>` element.
let dt (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "dt" attrs children

/// Create an HTML `<element>` element.
let element (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "element" attrs children

/// Create an HTML `<em>` element.
let em (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "em" attrs children

/// Create an HTML `<embed>` element.
let embed (attrs: list<Attr>) : Node =
    elt "embed" attrs []

/// Create an HTML `<fieldset>` element.
let fieldset (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "fieldset" attrs children

/// Create an HTML `<figcaption>` element.
let figcaption (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "figcaption" attrs children

/// Create an HTML `<figure>` element.
let figure (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "figure" attrs children

/// Create an HTML `<font>` element.
let font (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "font" attrs children

/// Create an HTML `<footer>` element.
let footer (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "footer" attrs children

/// Create an HTML `<form>` element.
let form (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "form" attrs children

/// Create an HTML `<frame>` element.
let frame (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "frame" attrs children

/// Create an HTML `<frameset>` element.
let frameset (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "frameset" attrs children

/// Create an HTML `<h1>` element.
let h1 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h1" attrs children

/// Create an HTML `<h2>` element.
let h2 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h2" attrs children

/// Create an HTML `<h3>` element.
let h3 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h3" attrs children

/// Create an HTML `<h4>` element.
let h4 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h4" attrs children

/// Create an HTML `<h5>` element.
let h5 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h5" attrs children

/// Create an HTML `<h6>` element.
let h6 (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "h6" attrs children

/// Create an HTML `<head>` element.
let head (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "head" attrs children

/// Create an HTML `<header>` element.
let header (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "header" attrs children

/// Create an HTML `<hr>` element.
let hr (attrs: list<Attr>) : Node =
    elt "hr" attrs []

/// Create an HTML `<html>` element.
let html (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "html" attrs children

/// Create an HTML `<i>` element.
let i (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "i" attrs children

/// Create an HTML `<iframe>` element.
let iframe (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "iframe" attrs children

/// Create an HTML `<img>` element.
let img (attrs: list<Attr>) : Node =
    elt "img" attrs []

/// Create an HTML `<input>` element.
let input (attrs: list<Attr>) : Node =
    elt "input" attrs []

/// Create an HTML `<ins>` element.
let ins (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "ins" attrs children

/// Create an HTML `<kbd>` element.
let kbd (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "kbd" attrs children

/// Create an HTML `<label>` element.
let label (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "label" attrs children

/// Create an HTML `<legend>` element.
let legend (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "legend" attrs children

/// Create an HTML `<li>` element.
let li (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "li" attrs children

/// Create an HTML `<link>` element.
let link (attrs: list<Attr>) : Node =
    elt "link" attrs []

/// Create an HTML `<main>` element.
let main (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "main" attrs children

/// Create an HTML `<map>` element.
let map (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "map" attrs children

/// Create an HTML `<mark>` element.
let mark (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "mark" attrs children

/// Create an HTML `<menu>` element.
let menu (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "menu" attrs children

/// Create an HTML `<menuitem>` element.
let menuitem (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "menuitem" attrs children

/// Create an HTML `<meta>` element.
let meta (attrs: list<Attr>) : Node =
    elt "meta" attrs []

/// Create an HTML `<meter>` element.
let meter (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "meter" attrs children

/// Create an HTML `<nav>` element.
let nav (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "nav" attrs children

/// Create an HTML `<noembed>` element.
let noembed (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "noembed" attrs children

/// Create an HTML `<noframes>` element.
let noframes (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "noframes" attrs children

/// Create an HTML `<noscript>` element.
let noscript (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "noscript" attrs children

/// Create an HTML `<object>` element.
let object (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "object" attrs children

/// Create an HTML `<ol>` element.
let ol (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "ol" attrs children

/// Create an HTML `<optgroup>` element.
let optgroup (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "optgroup" attrs children

/// Create an HTML `<option>` element.
let option (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "option" attrs children

/// Create an HTML `<output>` element.
let output (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "output" attrs children

/// Create an HTML `<p>` element.
let p (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "p" attrs children

/// Create an HTML `<param>` element.
let param (attrs: list<Attr>) : Node =
    elt "param" attrs []

/// Create an HTML `<picture>` element.
let picture (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "picture" attrs children

/// Create an HTML `<pre>` element.
let pre (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "pre" attrs children

/// Create an HTML `<progress>` element.
let progress (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "progress" attrs children

/// Create an HTML `<q>` element.
let q (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "q" attrs children

/// Create an HTML `<rb>` element.
let rb (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "rb" attrs children

/// Create an HTML `<rp>` element.
let rp (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "rp" attrs children

/// Create an HTML `<rt>` element.
let rt (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "rt" attrs children

/// Create an HTML `<rtc>` element.
let rtc (attrs: list<Attr>) : Node =
    elt "rtc" attrs []

/// Create an HTML `<ruby>` element.
let ruby (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "ruby" attrs children

/// Create an HTML `<s>` element.
let s (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "s" attrs children

/// Create an HTML `<samp>` element.
let samp (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "samp" attrs children

/// Create an HTML `<script>` element.
let script (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "script" attrs children

/// Create an HTML `<section>` element.
let section (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "section" attrs children

/// Create an HTML `<select>` element.
let select (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "select" attrs children

/// Create an HTML `<shadow>` element.
let shadow (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "shadow" attrs children

/// Create an HTML `<slot>` element.
let slot (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "slot" attrs children

/// Create an HTML `<small>` element.
let small (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "small" attrs children

/// Create an HTML `<source>` element.
let source (attrs: list<Attr>) : Node =
    elt "source" attrs []

/// Create an HTML `<span>` element.
let span (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "span" attrs children

/// Create an HTML `<strike>` element.
let strike (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "strike" attrs children

/// Create an HTML `<strong>` element.
let strong (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "strong" attrs children

/// Create an HTML `<style>` element.
let style (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "style" attrs children

/// Create an HTML `<sub>` element.
let sub (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "sub" attrs children

/// Create an HTML `<summary>` element.
let summary (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "summary" attrs children

/// Create an HTML `<sup>` element.
let sup (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "sup" attrs children

/// Create an HTML `<svg>` element.
let svg (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "svg" attrs children

/// Create an HTML `<table>` element.
let table (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "table" attrs children

/// Create an HTML `<tbody>` element.
let tbody (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "tbody" attrs children

/// Create an HTML `<td>` element.
let td (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "td" attrs children

/// Create an HTML `<template>` element.
let template (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "template" attrs children

/// Create an HTML `<textarea>` element.
let textarea (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "textarea" attrs children

/// Create an HTML `<tfoot>` element.
let tfoot (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "tfoot" attrs children

/// Create an HTML `<th>` element.
let th (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "th" attrs children

/// Create an HTML `<thead>` element.
let thead (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "thead" attrs children

/// Create an HTML `<time>` element.
let time (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "time" attrs children

/// Create an HTML `<title>` element.
let title (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "title" attrs children

/// Create an HTML `<tr>` element.
let tr (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "tr" attrs children

/// Create an HTML `<track>` element.
let track (attrs: list<Attr>) : Node =
    elt "track" attrs []

/// Create an HTML `<tt>` element.
let tt (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "tt" attrs children

/// Create an HTML `<u>` element.
let u (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "u" attrs children

/// Create an HTML `<ul>` element.
let ul (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "ul" attrs children

/// Create an HTML `<var>` element.
let var (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "var" attrs children

/// Create an HTML `<video>` element.
let video (attrs: list<Attr>) (children: list<Node>) : Node =
    elt "video" attrs children

/// Create an HTML `<wbr>` element.
let wbr (attrs: list<Attr>) : Node =
    elt "wbr" attrs []

// END TAGS

module attr =
    /// Create an HTML `class` attribute containing the given class names.
    let classes (classes: list<string>) : Attr =
        "class" => String.concat " " classes

    /// Bind an element reference.
    let inline ref (f: ElementReference -> unit) =
        Attr.Ref (Action<ElementReference>(f))

    let key (k: obj) =
        Attr.Key k

// BEGIN ATTRS
    /// Create an HTML `accept` attribute.
    let accept (v: obj) : Attr = "accept" => v

    /// Create an HTML `accept-charset` attribute.
    let acceptCharset (v: obj) : Attr = "accept-charset" => v

    /// Create an HTML `accesskey` attribute.
    let accesskey (v: obj) : Attr = "accesskey" => v

    /// Create an HTML `action` attribute.
    let action (v: obj) : Attr = "action" => v

    /// Create an HTML `align` attribute.
    let align (v: obj) : Attr = "align" => v

    /// Create an HTML `allow` attribute.
    let allow (v: obj) : Attr = "allow" => v

    /// Create an HTML `alt` attribute.
    let alt (v: obj) : Attr = "alt" => v

    /// Create an HTML `async` attribute.
    let async (v: obj) : Attr = "async" => v

    let ``aria-hidden`` (v: bool) : Attr = "aria-hidden" => v

    /// Create an HTML `autocapitalize` attribute.
    let autocapitalize (v: obj) : Attr = "autocapitalize" => v

    /// Create an HTML `autocomplete` attribute.
    let autocomplete (v: obj) : Attr = "autocomplete" => v

    /// Create an HTML `autofocus` attribute.
    let autofocus (v: obj) : Attr = "autofocus" => v

    /// Create an HTML `autoplay` attribute.
    let autoplay (v: obj) : Attr = "autoplay" => v

    /// Create an HTML `bgcolor` attribute.
    let bgcolor (v: obj) : Attr = "bgcolor" => v

    /// Create an HTML `border` attribute.
    let border (v: obj) : Attr = "border" => v

    /// Create an HTML `buffered` attribute.
    let buffered (v: obj) : Attr = "buffered" => v

    /// Create an HTML `challenge` attribute.
    let challenge (v: obj) : Attr = "challenge" => v

    /// Create an HTML `charset` attribute.
    let charset (v: obj) : Attr = "charset" => v

    /// Create an HTML `checked` attribute.
    let ``checked`` (v: obj) : Attr = "checked" => v

    /// Create an HTML `cite` attribute.
    let cite (v: obj) : Attr = "cite" => v

    /// Create an HTML `class` attribute.
    let ``class`` (v: obj) : Attr = "class" => v

    /// Create an HTML `code` attribute.
    let code (v: obj) : Attr = "code" => v

    /// Create an HTML `codebase` attribute.
    let codebase (v: obj) : Attr = "codebase" => v

    /// Create an HTML `color` attribute.
    let color (v: obj) : Attr = "color" => v

    /// Create an HTML `cols` attribute.
    let cols (v: obj) : Attr = "cols" => v

    /// Create an HTML `colspan` attribute.
    let colspan (v: obj) : Attr = "colspan" => v

    /// Create an HTML `content` attribute.
    let content (v: obj) : Attr = "content" => v

    /// Create an HTML `contenteditable` attribute.
    let contenteditable (v: obj) : Attr = "contenteditable" => v

    /// Create an HTML `contextmenu` attribute.
    let contextmenu (v: obj) : Attr = "contextmenu" => v

    /// Create an HTML `controls` attribute.
    let controls (v: obj) : Attr = "controls" => v

    /// Create an HTML `coords` attribute.
    let coords (v: obj) : Attr = "coords" => v

    /// Create an HTML `crossorigin` attribute.
    let crossorigin (v: obj) : Attr = "crossorigin" => v

    /// Create an HTML `csp` attribute.
    let csp (v: obj) : Attr = "csp" => v

    /// Create an HTML `data` attribute.
    let data (v: obj) : Attr = "data" => v

    /// Create an HTML `datetime` attribute.
    let datetime (v: obj) : Attr = "datetime" => v

    /// Create an HTML `decoding` attribute.
    let decoding (v: obj) : Attr = "decoding" => v

    /// Create an HTML `default` attribute.
    let ``default`` (v: obj) : Attr = "default" => v

    /// Create an HTML `defer` attribute.
    let defer (v: obj) : Attr = "defer" => v

    /// Create an HTML `dir` attribute.
    let dir (v: obj) : Attr = "dir" => v

    /// Create an HTML `dirname` attribute.
    let dirname (v: obj) : Attr = "dirname" => v

    /// Create an HTML `disabled` attribute.
    let disabled (v: obj) : Attr = "disabled" => v

    /// Create an HTML `download` attribute.
    let download (v: obj) : Attr = "download" => v

    /// Create an HTML `draggable` attribute.
    let draggable (v: obj) : Attr = "draggable" => v

    /// Create an HTML `dropzone` attribute.
    let dropzone (v: obj) : Attr = "dropzone" => v

    /// Create an HTML `enctype` attribute.
    let enctype (v: obj) : Attr = "enctype" => v

    /// Create an HTML `for` attribute.
    let ``for`` (v: obj) : Attr = "for" => v

    /// Create an HTML `form` attribute.
    let form (v: obj) : Attr = "form" => v

    /// Create an HTML `formaction` attribute.
    let formaction (v: obj) : Attr = "formaction" => v

    /// Create an HTML `headers` attribute.
    let headers (v: obj) : Attr = "headers" => v

    /// Create an HTML `height` attribute.
    let height (v: obj) : Attr = "height" => v

    /// Create an HTML `hidden` attribute.
    let hidden (v: obj) : Attr = "hidden" => v

    /// Create an HTML `high` attribute.
    let high (v: obj) : Attr = "high" => v

    /// Create an HTML `href` attribute.
    let href (v: obj) : Attr = "href" => v

    /// Create an HTML `hreflang` attribute.
    let hreflang (v: obj) : Attr = "hreflang" => v

    /// Create an HTML `http-equiv` attribute.
    let httpEquiv (v: obj) : Attr = "http-equiv" => v

    /// Create an HTML `icon` attribute.
    let icon (v: obj) : Attr = "icon" => v

    /// Create an HTML `id` attribute.
    let id (v: obj) : Attr = "id" => v

    /// Create an HTML `importance` attribute.
    let importance (v: obj) : Attr = "importance" => v

    /// Create an HTML `integrity` attribute.
    let integrity (v: obj) : Attr = "integrity" => v

    /// Create an HTML `ismap` attribute.
    let ismap (v: obj) : Attr = "ismap" => v

    /// Create an HTML `itemprop` attribute.
    let itemprop (v: obj) : Attr = "itemprop" => v

    /// Create an HTML `keytype` attribute.
    let keytype (v: obj) : Attr = "keytype" => v

    /// Create an HTML `kind` attribute.
    let kind (v: obj) : Attr = "kind" => v

    /// Create an HTML `label` attribute.
    let label (v: obj) : Attr = "label" => v

    /// Create an HTML `lang` attribute.
    let lang (v: obj) : Attr = "lang" => v

    /// Create an HTML `language` attribute.
    let language (v: obj) : Attr = "language" => v

    /// Create an HTML `lazyload` attribute.
    let lazyload (v: obj) : Attr = "lazyload" => v

    /// Create an HTML `list` attribute.
    let list (v: obj) : Attr = "list" => v

    /// Create an HTML `loop` attribute.
    let loop (v: obj) : Attr = "loop" => v

    /// Create an HTML `low` attribute.
    let low (v: obj) : Attr = "low" => v

    /// Create an HTML `manifest` attribute.
    let manifest (v: obj) : Attr = "manifest" => v

    /// Create an HTML `max` attribute.
    let max (v: obj) : Attr = "max" => v

    /// Create an HTML `maxlength` attribute.
    let maxlength (v: obj) : Attr = "maxlength" => v

    /// Create an HTML `media` attribute.
    let media (v: obj) : Attr = "media" => v

    /// Create an HTML `method` attribute.
    let method (v: obj) : Attr = "method" => v

    /// Create an HTML `min` attribute.
    let min (v: obj) : Attr = "min" => v

    /// Create an HTML `minlength` attribute.
    let minlength (v: obj) : Attr = "minlength" => v

    /// Create an HTML `multiple` attribute.
    let multiple (v: obj) : Attr = "multiple" => v

    /// Create an HTML `muted` attribute.
    let muted (v: obj) : Attr = "muted" => v

    /// Create an HTML `name` attribute.
    let name (v: obj) : Attr = "name" => v

    /// Create an HTML `novalidate` attribute.
    let novalidate (v: obj) : Attr = "novalidate" => v

    /// Create an HTML `open` attribute.
    let ``open`` (v: obj) : Attr = "open" => v

    /// Create an HTML `optimum` attribute.
    let optimum (v: obj) : Attr = "optimum" => v

    /// Create an HTML `pattern` attribute.
    let pattern (v: obj) : Attr = "pattern" => v

    /// Create an HTML `ping` attribute.
    let ping (v: obj) : Attr = "ping" => v

    /// Create an HTML `placeholder` attribute.
    let placeholder (v: obj) : Attr = "placeholder" => v

    /// Create an HTML `poster` attribute.
    let poster (v: obj) : Attr = "poster" => v

    /// Create an HTML `preload` attribute.
    let preload (v: obj) : Attr = "preload" => v

    /// Create an HTML `readonly` attribute.
    let readonly (v: obj) : Attr = "readonly" => v

    /// Create an HTML `rel` attribute.
    let rel (v: obj) : Attr = "rel" => v

    /// Create an HTML `required` attribute.
    let required (v: obj) : Attr = "required" => v

    /// Create an HTML `reversed` attribute.
    let reversed (v: obj) : Attr = "reversed" => v

    /// Create an HTML `rows` attribute.
    let rows (v: obj) : Attr = "rows" => v

    /// Create an HTML `rowspan` attribute.
    let rowspan (v: obj) : Attr = "rowspan" => v

    /// Create an HTML `sandbox` attribute.
    let sandbox (v: obj) : Attr = "sandbox" => v

    /// Create an HTML `scope` attribute.
    let scope (v: obj) : Attr = "scope" => v

    /// Create an HTML `selected` attribute.
    let selected (v: obj) : Attr = "selected" => v

    /// Create an HTML `shape` attribute.
    let shape (v: obj) : Attr = "shape" => v

    /// Create an HTML `size` attribute.
    let size (v: obj) : Attr = "size" => v

    /// Create an HTML `sizes` attribute.
    let sizes (v: obj) : Attr = "sizes" => v

    /// Create an HTML `slot` attribute.
    let slot (v: obj) : Attr = "slot" => v

    /// Create an HTML `span` attribute.
    let span (v: obj) : Attr = "span" => v

    /// Create an HTML `spellcheck` attribute.
    let spellcheck (v: obj) : Attr = "spellcheck" => v

    /// Create an HTML `src` attribute.
    let src (v: obj) : Attr = "src" => v

    /// Create an HTML `srcdoc` attribute.
    let srcdoc (v: obj) : Attr = "srcdoc" => v

    /// Create an HTML `srclang` attribute.
    let srclang (v: obj) : Attr = "srclang" => v

    /// Create an HTML `srcset` attribute.
    let srcset (v: obj) : Attr = "srcset" => v

    /// Create an HTML `start` attribute.
    let start (v: obj) : Attr = "start" => v

    /// Create an HTML `step` attribute.
    let step (v: obj) : Attr = "step" => v

    /// Create an HTML `style` attribute.
    let style (v: obj) : Attr = "style" => v

    /// Create an HTML `summary` attribute.
    let summary (v: obj) : Attr = "summary" => v

    /// Create an HTML `tabindex` attribute.
    let tabindex (v: obj) : Attr = "tabindex" => v

    /// Create an HTML `target` attribute.
    let target (v: obj) : Attr = "target" => v

    /// Create an HTML `title` attribute.
    let title (v: obj) : Attr = "title" => v

    /// Create an HTML `translate` attribute.
    let translate (v: obj) : Attr = "translate" => v

    /// Create an HTML `type` attribute.
    let ``type`` (v: obj) : Attr = "type" => v

    /// Create an HTML `usemap` attribute.
    let usemap (v: obj) : Attr = "usemap" => v

    /// Create an HTML `value` attribute.
    let value (v: obj) : Attr = "value" => v

    /// Create an HTML `width` attribute.
    let width (v: obj) : Attr = "width" => v

    /// Create an HTML `wrap` attribute.
    let wrap (v: obj) : Attr = "wrap" => v

// END ATTRS

module on =

    /// [omit]
    [<CompilerMessageAttribute("This method is intended for use in generated code only.", 10001, IsHidden=true, IsError=false)>]
    let inline eventInline< ^T, ^F when ^T :> EventArgs and ^F : (member Create : obj * Action< ^T> -> EventCallback< ^T>)> factory eventName (callback: ^T -> unit) : Attr =
        ExplicitAttr (fun builder sequence receiver ->
            builder.AddAttribute< ^T>(sequence, "on" + eventName,
                (^F : (member Create : obj * Action< ^T> -> EventCallback< ^T>)(factory, receiver, Action< ^T>(callback)))
            ))

    /// Create a handler for a HTML event of type EventArgs.
    let inline event< ^T when ^T :> EventArgs> eventName (callback: ^T -> unit) =
        eventInline< ^T, _> EventCallback.Factory eventName callback

// BEGIN EVENTS
    /// Create a handler for HTML event `focus`.
    let focus (callback: FocusEventArgs -> unit) : Attr =
        event "focus" callback

    /// Create a handler for HTML event `blur`.
    let blur (callback: FocusEventArgs -> unit) : Attr =
        event "blur" callback

    /// Create a handler for HTML event `focusin`.
    let focusin (callback: FocusEventArgs -> unit) : Attr =
        event "focusin" callback

    /// Create a handler for HTML event `focusout`.
    let focusout (callback: FocusEventArgs -> unit) : Attr =
        event "focusout" callback

    /// Create a handler for HTML event `mouseover`.
    let mouseover (callback: MouseEventArgs -> unit) : Attr =
        event "mouseover" callback

    /// Create a handler for HTML event `mouseout`.
    let mouseout (callback: MouseEventArgs -> unit) : Attr =
        event "mouseout" callback

    /// Create a handler for HTML event `mousemove`.
    let mousemove (callback: MouseEventArgs -> unit) : Attr =
        event "mousemove" callback

    /// Create a handler for HTML event `mousedown`.
    let mousedown (callback: MouseEventArgs -> unit) : Attr =
        event "mousedown" callback

    /// Create a handler for HTML event `mouseup`.
    let mouseup (callback: MouseEventArgs -> unit) : Attr =
        event "mouseup" callback

    /// Create a handler for HTML event `click`.
    let click (callback: MouseEventArgs -> unit) : Attr =
        event "click" callback

    /// Create a handler for HTML event `dblclick`.
    let dblclick (callback: MouseEventArgs -> unit) : Attr =
        event "dblclick" callback

    /// Create a handler for HTML event `wheel`.
    let wheel (callback: MouseEventArgs -> unit) : Attr =
        event "wheel" callback

    /// Create a handler for HTML event `mousewheel`.
    let mousewheel (callback: MouseEventArgs -> unit) : Attr =
        event "mousewheel" callback

    /// Create a handler for HTML event `contextmenu`.
    let contextmenu (callback: MouseEventArgs -> unit) : Attr =
        event "contextmenu" callback

    /// Create a handler for HTML event `drag`.
    let drag (callback: DragEventArgs -> unit) : Attr =
        event "drag" callback

    /// Create a handler for HTML event `dragend`.
    let dragend (callback: DragEventArgs -> unit) : Attr =
        event "dragend" callback

    /// Create a handler for HTML event `dragenter`.
    let dragenter (callback: DragEventArgs -> unit) : Attr =
        event "dragenter" callback

    /// Create a handler for HTML event `dragleave`.
    let dragleave (callback: DragEventArgs -> unit) : Attr =
        event "dragleave" callback

    /// Create a handler for HTML event `dragover`.
    let dragover (callback: DragEventArgs -> unit) : Attr =
        event "dragover" callback

    /// Create a handler for HTML event `dragstart`.
    let dragstart (callback: DragEventArgs -> unit) : Attr =
        event "dragstart" callback

    /// Create a handler for HTML event `drop`.
    let drop (callback: DragEventArgs -> unit) : Attr =
        event "drop" callback

    /// Create a handler for HTML event `keydown`.
    let keydown (callback: KeyboardEventArgs -> unit) : Attr =
        event "keydown" callback

    /// Create a handler for HTML event `keyup`.
    let keyup (callback: KeyboardEventArgs -> unit) : Attr =
        event "keyup" callback

    /// Create a handler for HTML event `keypress`.
    let keypress (callback: KeyboardEventArgs -> unit) : Attr =
        event "keypress" callback

    /// Create a handler for HTML event `change`.
    let change (callback: ChangeEventArgs -> unit) : Attr =
        event "change" callback

    /// Create a handler for HTML event `input`.
    let input (callback: ChangeEventArgs -> unit) : Attr =
        event "input" callback

    /// Create a handler for HTML event `invalid`.
    let invalid (callback: EventArgs -> unit) : Attr =
        event "invalid" callback

    /// Create a handler for HTML event `reset`.
    let reset (callback: EventArgs -> unit) : Attr =
        event "reset" callback

    /// Create a handler for HTML event `select`.
    let select (callback: EventArgs -> unit) : Attr =
        event "select" callback

    /// Create a handler for HTML event `selectstart`.
    let selectstart (callback: EventArgs -> unit) : Attr =
        event "selectstart" callback

    /// Create a handler for HTML event `selectionchange`.
    let selectionchange (callback: EventArgs -> unit) : Attr =
        event "selectionchange" callback

    /// Create a handler for HTML event `submit`.
    let submit (callback: EventArgs -> unit) : Attr =
        event "submit" callback

    /// Create a handler for HTML event `beforecopy`.
    let beforecopy (callback: EventArgs -> unit) : Attr =
        event "beforecopy" callback

    /// Create a handler for HTML event `beforecut`.
    let beforecut (callback: EventArgs -> unit) : Attr =
        event "beforecut" callback

    /// Create a handler for HTML event `beforepaste`.
    let beforepaste (callback: EventArgs -> unit) : Attr =
        event "beforepaste" callback

    /// Create a handler for HTML event `copy`.
    let copy (callback: ClipboardEventArgs -> unit) : Attr =
        event "copy" callback

    /// Create a handler for HTML event `cut`.
    let cut (callback: ClipboardEventArgs -> unit) : Attr =
        event "cut" callback

    /// Create a handler for HTML event `paste`.
    let paste (callback: ClipboardEventArgs -> unit) : Attr =
        event "paste" callback

    /// Create a handler for HTML event `touchcancel`.
    let touchcancel (callback: TouchEventArgs -> unit) : Attr =
        event "touchcancel" callback

    /// Create a handler for HTML event `touchend`.
    let touchend (callback: TouchEventArgs -> unit) : Attr =
        event "touchend" callback

    /// Create a handler for HTML event `touchmove`.
    let touchmove (callback: TouchEventArgs -> unit) : Attr =
        event "touchmove" callback

    /// Create a handler for HTML event `touchstart`.
    let touchstart (callback: TouchEventArgs -> unit) : Attr =
        event "touchstart" callback

    /// Create a handler for HTML event `touchenter`.
    let touchenter (callback: TouchEventArgs -> unit) : Attr =
        event "touchenter" callback

    /// Create a handler for HTML event `touchleave`.
    let touchleave (callback: TouchEventArgs -> unit) : Attr =
        event "touchleave" callback

    /// Create a handler for HTML event `pointercapture`.
    let pointercapture (callback: PointerEventArgs -> unit) : Attr =
        event "pointercapture" callback

    /// Create a handler for HTML event `lostpointercapture`.
    let lostpointercapture (callback: PointerEventArgs -> unit) : Attr =
        event "lostpointercapture" callback

    /// Create a handler for HTML event `pointercancel`.
    let pointercancel (callback: PointerEventArgs -> unit) : Attr =
        event "pointercancel" callback

    /// Create a handler for HTML event `pointerdown`.
    let pointerdown (callback: PointerEventArgs -> unit) : Attr =
        event "pointerdown" callback

    /// Create a handler for HTML event `pointerenter`.
    let pointerenter (callback: PointerEventArgs -> unit) : Attr =
        event "pointerenter" callback

    /// Create a handler for HTML event `pointerleave`.
    let pointerleave (callback: PointerEventArgs -> unit) : Attr =
        event "pointerleave" callback

    /// Create a handler for HTML event `pointermove`.
    let pointermove (callback: PointerEventArgs -> unit) : Attr =
        event "pointermove" callback

    /// Create a handler for HTML event `pointerout`.
    let pointerout (callback: PointerEventArgs -> unit) : Attr =
        event "pointerout" callback

    /// Create a handler for HTML event `pointerover`.
    let pointerover (callback: PointerEventArgs -> unit) : Attr =
        event "pointerover" callback

    /// Create a handler for HTML event `pointerup`.
    let pointerup (callback: PointerEventArgs -> unit) : Attr =
        event "pointerup" callback

    /// Create a handler for HTML event `canplay`.
    let canplay (callback: EventArgs -> unit) : Attr =
        event "canplay" callback

    /// Create a handler for HTML event `canplaythrough`.
    let canplaythrough (callback: EventArgs -> unit) : Attr =
        event "canplaythrough" callback

    /// Create a handler for HTML event `cuechange`.
    let cuechange (callback: EventArgs -> unit) : Attr =
        event "cuechange" callback

    /// Create a handler for HTML event `durationchange`.
    let durationchange (callback: EventArgs -> unit) : Attr =
        event "durationchange" callback

    /// Create a handler for HTML event `emptied`.
    let emptied (callback: EventArgs -> unit) : Attr =
        event "emptied" callback

    /// Create a handler for HTML event `pause`.
    let pause (callback: EventArgs -> unit) : Attr =
        event "pause" callback

    /// Create a handler for HTML event `play`.
    let play (callback: EventArgs -> unit) : Attr =
        event "play" callback

    /// Create a handler for HTML event `playing`.
    let playing (callback: EventArgs -> unit) : Attr =
        event "playing" callback

    /// Create a handler for HTML event `ratechange`.
    let ratechange (callback: EventArgs -> unit) : Attr =
        event "ratechange" callback

    /// Create a handler for HTML event `seeked`.
    let seeked (callback: EventArgs -> unit) : Attr =
        event "seeked" callback

    /// Create a handler for HTML event `seeking`.
    let seeking (callback: EventArgs -> unit) : Attr =
        event "seeking" callback

    /// Create a handler for HTML event `stalled`.
    let stalled (callback: EventArgs -> unit) : Attr =
        event "stalled" callback

    /// Create a handler for HTML event `stop`.
    let stop (callback: EventArgs -> unit) : Attr =
        event "stop" callback

    /// Create a handler for HTML event `suspend`.
    let suspend (callback: EventArgs -> unit) : Attr =
        event "suspend" callback

    /// Create a handler for HTML event `timeupdate`.
    let timeupdate (callback: EventArgs -> unit) : Attr =
        event "timeupdate" callback

    /// Create a handler for HTML event `volumechange`.
    let volumechange (callback: EventArgs -> unit) : Attr =
        event "volumechange" callback

    /// Create a handler for HTML event `waiting`.
    let waiting (callback: EventArgs -> unit) : Attr =
        event "waiting" callback

    /// Create a handler for HTML event `loadstart`.
    let loadstart (callback: ProgressEventArgs -> unit) : Attr =
        event "loadstart" callback

    /// Create a handler for HTML event `timeout`.
    let timeout (callback: ProgressEventArgs -> unit) : Attr =
        event "timeout" callback

    /// Create a handler for HTML event `abort`.
    let abort (callback: ProgressEventArgs -> unit) : Attr =
        event "abort" callback

    /// Create a handler for HTML event `load`.
    let load (callback: ProgressEventArgs -> unit) : Attr =
        event "load" callback

    /// Create a handler for HTML event `loadend`.
    let loadend (callback: ProgressEventArgs -> unit) : Attr =
        event "loadend" callback

    /// Create a handler for HTML event `progress`.
    let progress (callback: ProgressEventArgs -> unit) : Attr =
        event "progress" callback

    /// Create a handler for HTML event `error`.
    let error (callback: ProgressEventArgs -> unit) : Attr =
        event "error" callback

    /// Create a handler for HTML event `activate`.
    let activate (callback: EventArgs -> unit) : Attr =
        event "activate" callback

    /// Create a handler for HTML event `beforeactivate`.
    let beforeactivate (callback: EventArgs -> unit) : Attr =
        event "beforeactivate" callback

    /// Create a handler for HTML event `beforedeactivate`.
    let beforedeactivate (callback: EventArgs -> unit) : Attr =
        event "beforedeactivate" callback

    /// Create a handler for HTML event `deactivate`.
    let deactivate (callback: EventArgs -> unit) : Attr =
        event "deactivate" callback

    /// Create a handler for HTML event `ended`.
    let ended (callback: EventArgs -> unit) : Attr =
        event "ended" callback

    /// Create a handler for HTML event `fullscreenchange`.
    let fullscreenchange (callback: EventArgs -> unit) : Attr =
        event "fullscreenchange" callback

    /// Create a handler for HTML event `fullscreenerror`.
    let fullscreenerror (callback: EventArgs -> unit) : Attr =
        event "fullscreenerror" callback

    /// Create a handler for HTML event `loadeddata`.
    let loadeddata (callback: EventArgs -> unit) : Attr =
        event "loadeddata" callback

    /// Create a handler for HTML event `loadedmetadata`.
    let loadedmetadata (callback: EventArgs -> unit) : Attr =
        event "loadedmetadata" callback

    /// Create a handler for HTML event `pointerlockchange`.
    let pointerlockchange (callback: EventArgs -> unit) : Attr =
        event "pointerlockchange" callback

    /// Create a handler for HTML event `pointerlockerror`.
    let pointerlockerror (callback: EventArgs -> unit) : Attr =
        event "pointerlockerror" callback

    /// Create a handler for HTML event `readystatechange`.
    let readystatechange (callback: EventArgs -> unit) : Attr =
        event "readystatechange" callback

    /// Create a handler for HTML event `scroll`.
    let scroll (callback: EventArgs -> unit) : Attr =
        event "scroll" callback

// END EVENTS

/// Two-way binding for HTML input elements.
module bind =

    let private attr<'T, 'U> (valueName: string) (eventName: string) (value: 'T) (callback: 'U -> unit) =
        Attrs [
            valueName => value
            on.event eventName (fun (e: ChangeEventArgs) ->
                callback (unbox<'U> e.Value))
        ]

    let inline private attrParseValue< ^T when ^T : (static member TryParse : string * byref< ^T> -> bool)>
            (eventName: string) (value: ^T) (callback: ^T -> unit) =
        attr< ^T, string> "value" eventName value (fun s ->
            let mutable out = Unchecked.defaultof< ^T>
            if (^T : (static member TryParse : string * byref< ^T> -> bool)(s, &out))
            then callback out)

    /// Bind a boolean to the value of a checkbox.
    let ``checked`` (value: bool) (callback: bool -> unit) =
        attr<bool, bool> "checked" "change" value callback

    /// Bind a string to the value of an input.
    /// The value is updated on the oninput event.
    let input (value: string) (callback: string -> unit) =
        attr<string, string> "value" "input" value callback

    /// Bind a string to the value of an input.
    /// The value is updated on the onchange event.
    let change (value: string) (callback: string -> unit) =
        attr<string, string> "value" "change" value callback

    /// Bind an integer to the value of an input.
    /// The value is updated on the oninput event.
    let inputInt (value: int) (callback: int -> unit) =
        attrParseValue<int> "input" value callback

    /// Bind an integer to the value of an input.
    /// The value is updated on the onchange event.
    let changeInt (value: int) (callback: int -> unit) =
        attrParseValue<int> "change" value callback

    /// Bind a float to the value of an input.
    /// The value is updated on the oninput event.
    let inputFloat (value: float) (callback: float -> unit) =
        attrParseValue<float> "input" value callback

    /// Bind a float to the value of an input.
    /// The value is updated on the onchange event.
    let changeFloat (value: float) (callback: float -> unit) =
        attrParseValue<float> "change" value callback
