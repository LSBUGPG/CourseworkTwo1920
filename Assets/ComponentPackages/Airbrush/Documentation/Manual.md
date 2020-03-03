# Airbrush Screen Effect

This documentation describes how to use the `Airbrush` component in your project.

## Behaviours

- [`AirbrushScreenEffect`] shader
- [`GenerateNoise`] editor extension
- [`ScreenEffect`]

## AirbrushScreenEffect

This shader is designed for use as a screen effect. To use it, you need to create a material that uses the shader `Airbrush/Screen Effect`. The shader has the following parameters:

- Gaussian Noise (RGB)
- ScreenScale
- Blend

### Gaussian Noise

Assign a noise texture to the material's `Gaussian Noise` channel. (You can use the included `Generate Noise` editor extension, to create a random noise texture; see below.) The noise texture contains random values (0-255) in each of the R, G, and B channels. The distribution of the noise is a bell curve centered on the value 128.

### Screen Scale

Unity maps the screen from 0 to 1 in width and height. The Screen Scale maps this value to your noise texture. So if your screen is 1024 high and your noise texture is 512 high then your scale would need to be at least 2 (1024 / 512) to give you a one to one pixel ratio.

### Blend

The noise modifies the base colour of the pixel, adding the noise and scaling by the blend. A blend of 0 gives no noise, up to a blend of 1 giving +/- 50% noise.

## GenerateNoise

The script extends the editor to produce a noise texture of the required type, that is with random values distributed in a bell curve.

## ScreenEffect

This script applies the given Material effect to an attached camera object. An example `ScreenEffect` material is supplied.

[`AirbrushScreenEffect`]: #AirbrushScreenEffect
[`GenerateNoise`]: #GenerateNoise
[`ScreenEffect`]: #ScreenEffect
