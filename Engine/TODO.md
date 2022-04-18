## Super cool engine to-do list
- Make interfaces for some of the abstract classes
    - I might have things that can be updated and drawn without needing access to a contentmanager or spritebatch
- Reuse Entity objects in a pool
    - This will help if many entities are created and destroyed quickly
    - But it also means destroyed entities will sit and take up memory, waiting to be reused
    - Try: Configurable ratio of active to deceased entities, if deceased past ratio, clean up