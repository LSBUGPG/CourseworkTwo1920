# Leaderboard user guide

This documentation describes how to use the `Leaderboard` component in your project.

## Behaviours

- [`Table`]
- [`Leaderboard`]
- [`Rank`]

## Test behaviours

- [`TestAddScore`]

## Table

This behaviour represents the high score table data. It can be placed on any object in your game. The behaviour marks the object as `DontDestroyOnLoad` so you should put this in a boot scene. (A boot scene is a scene that is used to start the game, but only gets loaded once.)

### Properties

- `Size` is the total entries in the high score table
- `Minimum Initial Score` is the lowest score that will be randomly generated
- `Maximum Initial Score` is the highest score that will be randomly generated
- `Score Increment` the highest and lowest scores should be a multiple of this value
- `Initial Names` this array initialises the names used in random score generation

### `AddScore`

To add a score to the high score table, call the `AddScore` function passing a name as a string, and a score as an integer.

### `AddRandomScore`

This function is used to generate random scores. It is also used by the test code `TestAddScore` to add more random scores to the table. Internally, it calls `AddScore`.

### Caution

If any scene, other than a boot scene, contains this behaviour, the `Leaderboard` or `TestAddScore` scripts might reference the wrong one leading to incorrect scores.

## Leaderboard

Add the leaderboard behaviour to the `GameObject` representing leaderboard UI at the layout group level. This object must have the standard Unity `VerticalLayoutGroup` component. This behaviour creates a prefab based on the `Row Prefab` slot for each entry in a loaded `table` object. The `Row Prefab` entry must have the `Rank` behaviour on the root object of the prefab.

### Refresh

The refresh function can be called at any time after the `Start` function of the `Leaderboard` behaviour. It sends the list of `Rank` objects to the table object for it to fill in.

## Rank

This behaviour must be configured with three Unity UI `Text` objects. One each for the rank, name, and score fields. The function `SetRank` writes the given rank into the rank `Text` field as an integer. The function `SetName` writes the given name into the name `Text` field. The function `SetScore` writes the score as an integer into the score `Text` field, using the current default localisation settings for writing large numbers. For example, on a machine configured for the UK, the integer `1234567890` will display as `1,234,567,890`.

## TestAddScore

This test script is included in the example scene to generate an additional random score whenever you press the Space key. It is for test purposes only.

[`Table`]: #Table
[`Leaderboard`]: Leaderboard
[`Rank`]: #Rank
[`TestAddScore`]: #TestAddScore
