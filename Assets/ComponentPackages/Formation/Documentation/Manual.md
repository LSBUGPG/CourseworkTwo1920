# Formation user guide

This document explains the behaviours contained in this package and describes how to use them to create a formation movement system as used in space invader type games.

## Behaviours

- [`FormationFlyer`]
- [`FormationLeader`]

## FormationFlyer

This behaviour should be applied to each individual object that you want to move in formation. However, since the `FormationLeader` behaviour creates the objects in formation, you only need place this script on the prefabs for each type that you want in your formation.

The behaviour responds to the `Move` method which takes a direction to move as input. The direction vector is specified in world coordinates and includes the distance moved. Movement is performed using kinematic movement of the attached rigid body.

If movement causes the object to enter a trigger zone, the name of the zone is sent back to the `FormationLeader` object that created it.

## FormationLeader

This behaviour creates and moves a squad of `FormationFlyer` objects. You should place this script on an empty object positioned where you wish the lowest and leftmost object of your formation to start. It has the following configurable parameters:

- Row (array)
- Columns
- Row Spacing
- Column Spacing

### Row (array)

Each entry of this array should contain a prefab of the object you want to appear on this row of the formation. The number of entries in this array determines the number of rows in the grid. You can repeat the same prefab over multiple rows. You must have at least one row.

### Columns

The script creates this many columns on start. It must contain at least 1 column.

### Row Spacing and Column Spacing

This specifies in world space the distance between each row and each column of the formation. You should make sure you leave enough room for your objects to move and not collide with each other.

### Trigger Zones

When a `FormationFlyer` enters a trigger zone is sends the name of the zone back to the `FormationLeader` that created it. The formation leader expects three named zones to be defined in your scene:

- `LeftLimit`
- `RightLimit`
- `Target`

When a `FormationFlyer` reaches the `LeftLimit` or `RightLimit` zones, it orders the formation to advance once and then switch direction. The formation begins by moving left. It continues to advance until a flyer enters the `Target` zone. If this happens, the formation halts. Also, if all of the `FormationFlyer` objects are destroyed, the formation halts.

[`FormationFlyer`]: #FormationFlyer
[`FormationLeader`]: #FormationLeader