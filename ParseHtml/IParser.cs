﻿using AngleSharp.Html.Dom;

namespace ParseHtml
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
