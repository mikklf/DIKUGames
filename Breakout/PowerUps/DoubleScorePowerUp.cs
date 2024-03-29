using DIKUArcade.Entities;
using DIKUArcade.Events;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.IO;
using DIKUArcade.Timers;

namespace Breakout.PowerUps {

    public class DoubleScorePowerUp : PowerUp {

        public DoubleScorePowerUp(Shape shape, IBaseImage image) : base(shape, image) {

        }

        public override void Activate() {
            // Enable double score
            var enableEvent = new GameEvent();
            enableEvent.EventType = GameEventType.ControlEvent;
            enableEvent.Message = "ENABLE_DOUBLE_SCORE";
            BreakoutBus.GetBus().RegisterEvent(enableEvent);

            // Disable double score after x seconds
            var disableEvent = new GameEvent();
            disableEvent.EventType = GameEventType.TimedEvent;
            disableEvent.Message = "DISABLE_DOUBLE_SCORE";
            BreakoutBus.GetBus().RegisterTimedEvent(disableEvent, TimePeriod.NewMilliseconds(15000));

            this.DeleteEntity();
        }

    }
}