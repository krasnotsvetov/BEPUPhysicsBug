using BEPUphysics.BroadPhaseEntries;
using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using BEPUphysics.CollisionShapes.ConvexShapes;
using BEPUphysics.Entities;
using BEPUphysics.Constraints.SolverGroups;
using BEPUphysics.Paths;
using BEPUphysics.Paths.PathFollowing;
using BEPUphysics.Constraints.TwoEntity.Motors;
using BEPUphysics.CollisionShapes;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using BEPUphysicsDemos.AlternateMovement;

namespace BEPUphysicsDemos.Demos
{
    /// <summary>
    /// A playground for the character controller to frolic in.
    /// </summary>
    public class FullSceneBugDemo : StandardDemo
    {
        /// <summary>
        /// Constructs a new demo.
        /// </summary>
        /// <param name="game">Game owning this demo.</param>
        public FullSceneBugDemo(DemosGame game)
            : base(game)
        {

            character = new BugShowerCharacterController(Space, game.Camera, game);
            Space.ForceUpdater.Gravity = new Vector3(0, -16, 0);
            game.Camera.Position = new Vector3(5, 0.85f, 4);
            game.Camera.ViewDirection = new Vector3(0, 0, 1);
            //Since this is the character playground, turn on the character by default.
            character.Activate();
            //Having the character body visible would be a bit distracting.
            character.CharacterController.Body.Tag = "noDisplayObject";

            //Load in mesh data for the environment.
            Vector3[] staticTriangleVertices;
            int[] staticTriangleIndices;


            var playgroundModel = game.Content.Load<Model>("bugFullRoom");
            //This is a little convenience method used to extract vertices and indices from a model.
            //It doesn't do anything special; any approach that gets valid vertices and indices will work.
            ModelDataExtractor.GetVerticesAndIndicesFromModel(playgroundModel, out staticTriangleVertices, out staticTriangleIndices);
            var staticMesh = new StaticMesh(staticTriangleVertices, staticTriangleIndices, new AffineTransform(new Vector3(1, 1, 1), Quaternion.Identity, new Vector3(0, 0, 0)));
            staticMesh.Sidedness = TriangleSidedness.Counterclockwise;

            Space.Add(staticMesh);
            game.ModelDrawer.Add(staticMesh);
        }


        public override void Update(float dt)
        {
            //Increment the time.  Note that the space's timestep is used
            //instead of the method's dt.  This is because the demos, by
            //default, update the space once each game update.  Using the
            //space's update time keeps things synchronized.
            //If the engine is using internal time stepping,
            //the passed in dt should be used instead (or put this logic into
            //an updateable that runs with space updates).
            base.Update(dt);
        }

        public override void DrawUI()
        {
#if XBOX360
            Game.DataTextDrawer.Draw("Press \"A\" to toggle the character.", new Microsoft.Xna.Framework.(50, 50));
#else
            Game.DataTextDrawer.Draw("Press \"C\" to toggle the character.", new Microsoft.Xna.Framework.Vector2(50, 50));
#endif
            base.DrawUI();
        }

        /// <summary>
        /// Gets the name of the simulation.
        /// </summary>
        public override string Name
        {
            get { return "Bug example"; }
        }
    }
}