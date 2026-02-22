<div align="center">

# Procedural Cross-Section System

<a href="https://www.youtube.com/watch?v=IGzDsBVwsAA">
  <img src="https://img.youtube.com/vi/IGzDsBVwsAA/maxresdefault.jpg" width="100%">
</a>

</div>

### System Overview
This project is a high-performance slicing system developed for Unity's Universal Render Pipeline (URP). It enables real-time cross-sections of 3D objects by handling the slicing logic entirely on the GPU. This approach provides a lightweight alternative to traditional mesh-boolean operations, which are often too heavy for real-time gameplay or mobile performance.

### Technical Implementation
The system focuses on mathematical precision and GPU optimization to create the illusion of solid objects from hollow meshes:

- **Object-Space Clipping:** Built a custom Shader Graph that uses Object-space coordinates to define a cutting plane. This keeps the slicing consistent even when the object is moving, rotating, or scaling in the scene.
- **Back-face Reconstruction:** Enabled double-sided rendering and used the IsFrontFace semantic to detect the model's interior. This allows the shader to dynamically apply a different color or texture to the exposed surfaces, making the hollow model appear solid.
- **Optimized Alpha Clipping:** Used the Discard instruction via Alpha Clipping instead of standard transparency. This ensures that the sliced parts of the geometry are completely ignored by the engine, maintaining correct shadow casting and depth buffer behavior without the performance cost of overdraw.
- **Efficient Parameter Control (Slicer.cs):** The controller script uses MaterialPropertyBlocks to send data to the GPU. This prevents the creation of unique material instances in memory, allowing multiple objects to be sliced at different heights simultaneously while keeping the system memory-efficient.

### System Scalability
The system is designed to be modular. Because it relies on shader logic rather than geometry modification, it can be applied to any 3D mesh instantly. It is ideal for interactive gameplay mechanics, technical visualizations, or stylized destruction effects where performance and clean visual results are the priority.
