using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using Avalonia.Media.Fonts;

public static partial class GlobalFonts
{
    public static FontFamily NotoColorEmojiSubset { get; } =
        new FontFamily(@"avares://FontSubset.Avalonia/Assets/Fonts#NotoColorEmoji");

    private static IEnumerable<FontFallback> Fallbacks =>
        NotoEmojiColorFallbacks;

    private static IEnumerable<FontFallback> NotoEmojiColorFallbacks =>
    [
        new FontFallback()
        {
            FontFamily = NotoColorEmojiSubset,
            UnicodeRange = new UnicodeRange(0x1F600, 0x1F64F)
        }
    ];

    /// <summary>
    /// Demonstrates how to remove reliance upon system-provided fonts
    /// </summary>
    public static void DefaultConfigureFonts(FontManager fontManager)
    {
        // Remove system fonts
        fontManager.RemoveFontCollection(new Uri("fonts:SystemFonts"));

        // Add our default font which will be the only font available besides the augmented fallbacks
        var fc = new EmbeddedFontCollection(new Uri("fonts:SystemFonts", UriKind.Absolute),
            new Uri("avares://FontSubset.Avalonia/Assets/Fonts#Bricolage Grotesque", UriKind.Absolute));

        fontManager.AddFontCollection(fc);
    }

    private static FontManagerOptions CreateDefaultFontManagerOptions() =>
        new FontManagerOptions()
        {
            FontFallbacks = GlobalFonts.Fallbacks.ToList(),
            DefaultFamilyName = ""
        };
}
