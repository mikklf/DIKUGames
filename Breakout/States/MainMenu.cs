using System.IO;
using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using DIKUArcade.State;

namespace Breakout.States
{
    public class MainMenu : IGameState {

        private Entity backgroundImage;
        private static MainMenu instance = null;
        private Text[] menuButtons;
        private int activeMenuButton;


        public MainMenu() {
            backgroundImage = new Entity(
                new StationaryShape(new Vec2F(0f, 0f), new Vec2F(1f, 1f)),
                new Image(Path.Combine("Assets", "Images", "shipit_titlescreen.png"))
            );

            menuButtons = new Text[] {
                new Text("New Game", new Vec2F(0.22f, 0.3f), new Vec2F(0.4f, 0.4f)),
                new Text("Quit", new Vec2F(0.22f, 0.20f), new Vec2F(0.4f, 0.4f))
            };

            menuButtons[0].SetColor(new Vec3I(229, 192, 20));
            menuButtons[1].SetColor(new Vec3I(255, 255, 255));

            activeMenuButton = 0;
        }

        public static MainMenu GetInstance() {
            return MainMenu.instance ?? (MainMenu.instance = new MainMenu());
        }

        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                switch (key) {
                    case KeyboardKey.Up:
                        activeMenuButton = 0;
                        menuButtons[1].SetColor(new Vec3I(255, 255, 255));
                        menuButtons[0].SetColor(new Vec3I(229, 192, 20));
                        break;

                    case KeyboardKey.Down:
                        activeMenuButton = 1;
                        menuButtons[0].SetColor(new Vec3I(255, 255, 255));
                        menuButtons[1].SetColor(new Vec3I(229, 192, 20));
                        break;

                    case KeyboardKey.Enter:
                        var gameEvent = new GameEvent();
                        if (activeMenuButton == 0) {
                            gameEvent.EventType = GameEventType.GameStateEvent;
                            gameEvent.Message = "GAME_RUNNING";
                        } else {
                            gameEvent.EventType = GameEventType.WindowEvent;
                            gameEvent.Message = "CLOSE_WINDOW";
                        }
                        BreakoutBus.GetBus().RegisterEvent(gameEvent);
                        break;

                }
            }
        }


        public void RenderState() {
            backgroundImage.RenderEntity();
            foreach (var button in menuButtons)
            {
                button.RenderText();
            }
        }

        public void ResetState() {

        }

        public void UpdateState() {

        }
    }
}