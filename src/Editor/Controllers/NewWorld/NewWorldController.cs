using System;
using System.Windows.Forms;
using Junior.Common.Net35;
using NathanAlden.TextAdventure.Common.Config;
using NathanAlden.TextAdventure.Common.WindowsForms;
using NathanAlden.TextAdventure.Editor.Configuration;
using NathanAlden.TextAdventure.Models.World;

namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    public class NewWorldController : Controller<INewWorldView>, INewWorldController
    {
        private readonly IConfigFile<Config> _configFile;
        private readonly IGuidFactory _guidFactory;
        private readonly ISystemClock _systemClock;
        private readonly NewWorldViewModel _viewModel;

        public NewWorldController(INewWorldView newWorldView, IConfigFile<Config> configFile, IGuidFactory guidFactory, ISystemClock systemClock)
            : base(newWorldView)
        {
            _configFile = configFile.EnsureNotNull(nameof(configFile));
            _guidFactory = guidFactory.EnsureNotNull(nameof(guidFactory));
            _systemClock = systemClock.EnsureNotNull(nameof(systemClock));
            _viewModel = new NewWorldViewModel
                         {
                             Author = _configFile.Config.Views.NewWorld.DefaultAuthor,
                             IdAsGuid = _guidFactory.Random(),
                             Version = "1.0"
                         };

            AddDisposables(View.GenerateId.Subscribe(x => _viewModel.IdAsGuid = _guidFactory.Random()));
        }

        public WorldModel ShowView(IWin32Window owner)
        {
            owner.ThrowIfNull(nameof(owner));

            if (View.ShowView(owner, _viewModel) != DialogResult.OK)
            {
                return null;
            }

            _configFile.Config.Views.NewWorld.DefaultAuthor = _viewModel.Author;
            _configFile.Save();

            return new WorldModel
                   {
                       Author = _viewModel.Author,
                       CreatedTimestamp = _systemClock.LocalDateTime,
                       Id = _viewModel.IdAsGuid,
                       Name = _viewModel.WorldName,
                       Resources =
                       {
                           Charactersets =
                           {
                               new WorldResourceCharactersetModel
                               {
                                   Id = _guidFactory.Random(),
                                   Name = "standard",
                                   PngBase64 = CharactersetResources.standard.AsBase64Png()
                               }
                           }
                       },
                       Versions =
                       {
                           World = _viewModel.Version
                       }
                   };
        }
    }
}