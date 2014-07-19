﻿// SampSharp
// Copyright (C) 2014 Tim Potze
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org>

using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Controllers
{
    /// <summary>
    ///     A controller processing all vehicle actions.
    /// </summary>
    public class VehicleController : IEventListener, ITypeProvider
    {
        /// <summary>
        ///     Registers the events this VehicleController wants to listen to.
        /// </summary>
        /// <param name="gameMode">The running GameMode.</param>
        public virtual void RegisterEvents(BaseMode gameMode)
        {
            //Register all vehicle events
            gameMode.VehicleSpawned += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnSpawn(args);
            gameMode.VehicleDied += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnDeath(args);
            gameMode.PlayerEnterVehicle += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnPlayerEnter(args);
            gameMode.PlayerExitVehicle += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnPlayerExit(args);
            gameMode.VehicleMod += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnMod(args);
            gameMode.VehiclePaintjobApplied +=
                (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnPaintjobApplied(args);
            gameMode.VehicleResprayed += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnResprayed(args);
            gameMode.VehicleDamageStatusUpdated +=
                (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnDamageStatusUpdated(args);
            gameMode.UnoccupiedVehicleUpdated +=
                (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnUnoccupiedUpdate(args);
            gameMode.VehicleStreamIn += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnStreamIn(args);
            gameMode.VehicleStreamOut += (sender, args) => Vehicle.FindOrCreate(args.VehicleId).OnStreamOut(args);
        }

        /// <summary>
        ///     Registers types this VehicleController requires the system to use.
        /// </summary>
        public virtual void RegisterTypes()
        {
            Vehicle.Register<Vehicle>();
        }
    }
}