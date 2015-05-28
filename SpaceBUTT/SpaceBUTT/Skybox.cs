﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceBUTT
{
    public class Skybox 
    {

       public Texture2D[] skyboxTextures;
       public Model skyboxModel;
       public Effect effect;
       public GraphicsDevice device;


        
     

        private Model LoadModel(string assetName, out Texture2D[] textures)
        {
            
            Model newModel = Content.Load<Model>("skybox2");
            textures = new Texture2D[newModel.Meshes.Count];
            int i = 0;
            foreach (ModelMesh mesh in newModel.Meshes)
                foreach (BasicEffect currentEffect in mesh.Effects)
                    textures[i++] = currentEffect.Texture;

            foreach (ModelMesh mesh in newModel.Meshes)
                foreach (ModelMeshPart meshPart in mesh.MeshParts)
                    meshPart.Effect = effect.Clone();

            return newModel;
        }

        public void Update(GameTime gameTime)
        {

            //Get keyboard state
            KeyboardState keyState = Keyboard.GetState();


        }
        public void DrawSkybox()
         {
             SamplerState ss = new SamplerState();
             ss.AddressU = TextureAddressMode.Clamp;
             ss.AddressV = TextureAddressMode.Clamp;
             device.SamplerStates[0] = ss;
 
             DepthStencilState dss = new DepthStencilState();
             dss.DepthBufferEnable = false;
             device.DepthStencilState = dss;
 
             Matrix[] skyboxTransforms = new Matrix[skyboxModel.Bones.Count];
             skyboxModel.CopyAbsoluteBoneTransformsTo(skyboxTransforms);
             int i = 0;
             foreach (ModelMesh mesh in skyboxModel.Meshes)
             {
                 foreach (Effect currentEffect in mesh.Effects)
                 {
                     Matrix worldMatrix = skyboxTransforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(modelPosition);
                     currentEffect.CurrentTechnique = currentEffect.Techniques["Textured"];
                     currentEffect.Parameters["xWorld"].SetValue(worldMatrix);
                     currentEffect.Parameters["xView"].SetValue(View);
                     currentEffect.Parameters["xProjection"].SetValue(Projection);
                     currentEffect.Parameters["xTexture"].SetValue(skyboxTextures[i++]);
                 }
                 mesh.Draw();
             }
 
             dss = new DepthStencilState();
             dss.DepthBufferEnable = true;
             device.DepthStencilState = dss;
         }
     }


    }
*/