﻿using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.Pippidon.UI;
using osu.Framework.Input.Bindings;
using osu.Framework.IO.Stores;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Game.Rulesets.Pippidon.Mods;

namespace osu.Game.Rulesets.Pippidon
{
    public class PippidonRuleset : Ruleset
    {
        public ResourceStore<byte[]> ResourceStore;
        public TextureStore TextureStore;

        public PippidonRuleset(RulesetInfo rulesetInfo) : base(rulesetInfo)
        {
            ResourceStore = new NamespacedResourceStore<byte[]>(new DllResourceStore("osu.Game.Rulesets.Pippidon.dll"), "Resources");
            TextureStore = new TextureStore(new RawTextureLoaderStore(new NamespacedResourceStore<byte[]>(ResourceStore, @"Textures")));
        }

        public override string Description => "pippipidoooooon";

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new PippidonRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap, Mod[] mods = null) => new PippidonDifficultyCalculator();

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.Special:
                    return new[] { new PippidonModAutoplay() };
                default:
                    return new Mod[] { null };
            }
        }

        public override string ShortName => "pipidon";

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.W, PippidonAction.MoveUp),
            new KeyBinding(InputKey.S, PippidonAction.MoveDown),
            new KeyBinding(InputKey.D, PippidonAction.Boost),
        };

        public override Drawable CreateIcon() => new Sprite
        {
            Margin = new MarginPadding { Top = 3 },
            Texture = TextureStore.Get("coin"),
        };
    }
}
