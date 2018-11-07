#region

using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors.PetBehaviors;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()

        .Init("Larry Gigsman, the Superhuman",
                new State(
                    new State("default",
                        new Wander(0.05),
                        new PlayerWithinTransition(8, "taunt")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt",
                        new Taunt("You can't possibly beat me..the almighty Larry Gigsman!"),
                        new TimedTransition(10000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("You don't realize that I am the best of the best!"),
                        new TimedTransition(10000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("Look me in the eye...Do you really wish to fight me?"),
                        new PlayerTextTransition("Start1", "Yes, Daddy", 5, false, true)
                        )
                      ),
                    new State(
                        new SetAltTexture(0),
                        new Shoot(10, 4, projectileIndex: 5, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 6, shootAngle: 14, coolDown: 3000, coolDownOffset: 1000),
                        new Prioritize(
                            new Follow(0.4, acquireRange: 15, range: 8),
                            new Wander(0.6)
                            ),
                        new TimedTransition(9200, "Rush"),
                    new State("Start1",
                        new Shoot(10, 10, projectileIndex: 3, coolDown: 1000),
                        new TimedTransition(1000, "Start2")
                        ),
                    new State("Start2",
                        new Shoot(10, 10, projectileIndex: 4, coolDown: 1000),
                        new TimedTransition(1000, "Start1")
                        )
                        ),
                    new State("Rush",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Taunt(0.50, "You won't get away!"),
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(1)
                            ),
                        new Shoot(10, 12, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, 1, projectileIndex: 6, coolDown: 500),
                        new TimedTransition(7400, "Pink")
                        ),
                    new State(
                        new Shoot(10, 8, projectileIndex: 5, coolDown: 2000),
                        new Shoot(10, 4, projectileIndex: 6, coolDown: 4000, coolDownOffset: 2000),
                        new Prioritize(
                            new Follow(0.4, acquireRange: 15, range: 8),
                            new Wander(0.6)
                            ),
                        new TimedTransition(9200, "Start1"),
                    new State("Pink",
                        new SetAltTexture(2),
                        new Shoot(10, 5, projectileIndex: 0, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Orange")
                        ),
                    new State("Orange",
                        new SetAltTexture(1),
                        new Shoot(10, 5, projectileIndex: 1, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Green")
                        ),
                    new State("Green",
                        new SetAltTexture(3),
                        new Shoot(10, 5, projectileIndex: 2, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Pink")
                        )
                        ),
                    new State("dead1",
                        new SetAltTexture(4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I DONT WANNA DIE TODAY"),
                        new TimedTransition(4800, "officiallydead")
                        ),
                    new State("officiallydead",
                        new Suicide()
                        )
                    ),
                new Threshold(0.025,
                    new ItemLoot("Sword of Orange Fever", 0.6),
                    new ItemLoot("Papercutter", 0.6),
                    new ItemLoot("No Sunflowers", 0.6),
                    new ItemLoot("Smileyman's Shank", 0.6),
                    new ItemLoot("Thisswordugly", 0.6),
                    new ItemLoot("Tree Stick Red Wand", 0.6),
                    new ItemLoot("Eon", 0.04),
                    new ItemLoot("Gold Cache", 0.8),
                    new ItemLoot("Larry Gun", 0.01)
                )

          )
            .Init("White Fountain",
                new State(
                    new HealPlayer(5, coolDown: 450, healAmount: 100)
                    )
            )

         .Init("Crude Flame",
                new State(
                    new State("start",
                        new SetAltTexture(0)
                    // new TimedTransition(2000, "suicide")
                    //  new EntityFollow(3, 100, 1)//,
                    //    new HealPlayer(5, coolDown: 1000, healAmount: 20)
                    ),
                      new State("tier0",
                        new SetAltTexture(1),
                         new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 40)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )
         .Init("Blood Red Flame",
                new State(
                    new State("start",
                        new SetAltTexture(0)
                    //  new TimedTransition(2000, "suicide")
                    //new HealPlayer(5, coolDown: 1000, healAmount: 30)
                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                           new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 50)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )
         .Init("Blue Flame",
                new State(
                    new State("start",
                        new SetAltTexture(0)
                    //new TimedTransition(2000, "suicide")
                    // new EntityFollow(3, 100, 1)//,
                    //  new HealPlayer(5, coolDown: 500, healAmount: 20)
                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                           new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                        new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 60)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )
         .Init("Black Flame",
                new State(
                    new State("start",
                          new SetAltTexture(0)
                    //  new TimedTransition(2000, "suicide")
                    //  new HealPlayer(5, coolDown: 500, healAmount: 25)
                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                           new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 65)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )
        .Init("Ghost Flame",
                new State(
                    new State("start",
                          new SetAltTexture(0)
                    //   new TimedTransition(2000, "suicide")
                    //new HealPlayer(5, coolDown: 500, healAmount: 35)
                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                           new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                           new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 70)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )
         .Init("Amber Flame",
                new State(
                    new State("start",
                          new SetAltTexture(0)
                    //  new TimedTransition(2000, "suicide")
                    //  new HealPlayer(5, coolDown: 500, healAmount: 40)
                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                           new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                            new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                          new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                         new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                         new HealPlayer(5, coolDown: 1000, healAmount: 85)
                      ),
                     new State("suicide",
                   new Suicide()
                      )


                    )

            )
        .Init("Toxic Flame",
                new State(
                    new State("start",
                          new SetAltTexture(0)
                    //  new TimedTransition(2000, "suicide")

                    ),
                      new State("tier0",
                          new SetAltTexture(1),
                          new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Crude Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Crude Totem", radiusVariance: 0.5),
                          new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                       new State("tier1",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blood Red Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blood Red Totem", radiusVariance: 0.5),
                             new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                       new State("tier2",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Blue Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Blue Totem", radiusVariance: 0.5),
                             new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                       new State("tier3",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Black Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Black Totem", radiusVariance: 0.5),
                             new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                       new State("tier4",
                           new SetAltTexture(1),
                            new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Ghost Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Ghost Totem", radiusVariance: 0.5),
                             new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                        new State("tier5",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Amber Totem", 6, "start"),
                        new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Amber Totem", radiusVariance: 0.5),
                              new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                        new State("tier6",
                            new SetAltTexture(1),
                             new Order(100, "Crude Totem", "visible"),
                          new Order(100, "Blood Red Totem", "visible"),
                          new Order(100, "Blue Totem", "visible"),
                          new Order(100, "Black Totem", "visible"),
                          new Order(100, "Ghost Totem", "visible"),
                          new Order(100, "Amber Totem", "visible"),
                          new Order(100, "Toxic Totem", "visible"),
                        new EntityNotExistsTransition("Toxic Totem", 6, "start"),
                         new ChangeSize(10, 100),
                        new Orbit(.6, 3, target: "Toxic Totem", radiusVariance: 0.5),
                              new HealPlayer(5, coolDown: 1000, healAmount: 100)
                      ),
                     new State("suicide",
                   new Suicide()
                      )

                    )

            )

        //.Init("Crude Totem",
        //        new State(
        //            new State("start",
        //                new EntityExistsTransition("Crude Flame", 6, "spawnTotem"),
        //             new TimedTransition(2000, "suicide")

        //            ),
        //                new State("spawnTotem",
        //           new Reproduce("Crude Totem2", coolDown: 100, densityMax: 1),
        //           new TimedTransition(300, "suicide")
        //              ),
        //             new State("suicide",
        //              new Order(100, "Crude Flame", "tier0")
        //              )

        //            )

        //    )

          .Init("Crude Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),
                  
                   new Order(100, "Crude Flame", "tier0"),
                   new Order(100, "Blood Red Flame", "tier0"),
                   new Order(100, "Blue Flame", "tier0"),
                   new Order(100, "Black Flame", "tier0"),
                   new Order(100, "Ghost Flame", "tier0"),
                   new Order(100, "Amber Flame", "tier0"),
                   new Order(100, "Toxic Flame", "tier0"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                       new Order(100, "Crude Flame", "tier0"),
                       new Order(100, "Blood Red Flame", "tier0"),
                       new Order(100, "Blue Flame", "tier0"),
                       new Order(100, "Black Flame", "tier0"),
                       new Order(100, "Ghost Flame", "tier0"),
                       new Order(100, "Amber Flame", "tier0"),
                       new Order(100, "Toxic Flame", "tier0")
                      )
                    )
            )
          .Init("Blood Red Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier1"),
                   new Order(100, "Blood Red Flame", "tier1"),
                   new Order(100, "Blue Flame", "tier1"),
                   new Order(100, "Black Flame", "tier1"),
                   new Order(100, "Ghost Flame", "tier1"),
                   new Order(100, "Amber Flame", "tier1"),
                   new Order(100, "Toxic Flame", "tier1"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                       new Order(100, "Crude Flame", "tier1"),
                   new Order(100, "Blood Red Flame", "tier1"),
                   new Order(100, "Blue Flame", "tier1"),
                   new Order(100, "Black Flame", "tier1"),
                   new Order(100, "Ghost Flame", "tier1"),
                   new Order(100, "Amber Flame", "tier1"),
                   new Order(100, "Toxic Flame", "tier1")
                      )
                    )
            )
         .Init("Blue Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier2"),
                   new Order(100, "Blood Red Flame", "tier2"),
                   new Order(100, "Blue Flame", "tier2"),
                   new Order(100, "Black Flame", "tier2"),
                   new Order(100, "Ghost Flame", "tier2"),
                   new Order(100, "Amber Flame", "tier2"),
                   new Order(100, "Toxic Flame", "tier2"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                        new Order(100, "Crude Flame", "tier2"),
                   new Order(100, "Blood Red Flame", "tier2"),
                   new Order(100, "Blue Flame", "tier2"),
                   new Order(100, "Black Flame", "tier2"),
                   new Order(100, "Ghost Flame", "tier2"),
                   new Order(100, "Amber Flame", "tier2"),
                   new Order(100, "Toxic Flame", "tier2")
                      )
                    )
            )
          .Init("Black Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier3"),
                   new Order(100, "Blood Red Flame", "tier3"),
                   new Order(100, "Blue Flame", "tier3"),
                   new Order(100, "Black Flame", "tier3"),
                   new Order(100, "Ghost Flame", "tier3"),
                   new Order(100, "Amber Flame", "tier3"),
                   new Order(100, "Toxic Flame", "tier3"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                        new Order(100, "Crude Flame", "tier3"),
                   new Order(100, "Blood Red Flame", "tier3"),
                   new Order(100, "Blue Flame", "tier3"),
                   new Order(100, "Black Flame", "tier3"),
                   new Order(100, "Ghost Flame", "tier3"),
                   new Order(100, "Amber Flame", "tier3"),
                   new Order(100, "Toxic Flame", "tier3")
                      )
                    )
            )
         .Init("Ghost Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier4"),
                   new Order(100, "Blood Red Flame", "tier4"),
                   new Order(100, "Blue Flame", "tier4"),
                   new Order(100, "Black Flame", "tier4"),
                   new Order(100, "Ghost Flame", "tier4"),
                   new Order(100, "Amber Flame", "tier4"),
                   new Order(100, "Toxic Flame", "tier4"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                         new Order(100, "Crude Flame", "tier4"),
                   new Order(100, "Blood Red Flame", "tier4"),
                   new Order(100, "Blue Flame", "tier4"),
                   new Order(100, "Black Flame", "tier4"),
                   new Order(100, "Ghost Flame", "tier4"),
                   new Order(100, "Amber Flame", "tier4"),
                   new Order(100, "Toxic Flame", "tier4")
                      )
                    )
            )
         .Init("Amber Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier5"),
                   new Order(100, "Blood Red Flame", "tier5"),
                   new Order(100, "Blue Flame", "tier5"),
                   new Order(100, "Black Flame", "tier5"),
                   new Order(100, "Ghost Flame", "tier5"),
                   new Order(100, "Amber Flame", "tier5"),
                   new Order(100, "Toxic Flame", "tier5"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                       new Order(100, "Crude Flame", "tier5"),
                   new Order(100, "Blood Red Flame", "tier5"),
                   new Order(100, "Blue Flame", "tier5"),
                   new Order(100, "Black Flame", "tier5"),
                   new Order(100, "Ghost Flame", "tier5"),
                   new Order(100, "Amber Flame", "tier5"),
                   new Order(100, "Toxic Flame", "tier5")
                      )
                    )
            )
         .Init("Toxic Totem",
                new State(
                     new State("start",
                   //   new EntityFollow(3, 100, 1),

                   new Order(100, "Crude Flame", "tier6"),
                   new Order(100, "Blood Red Flame", "tier6"),
                   new Order(100, "Blue Flame", "tier6"),
                   new Order(100, "Black Flame", "tier6"),
                   new Order(100, "Ghost Flame", "tier6"),
                   new Order(100, "Amber Flame", "tier6"),
                   new Order(100, "Toxic Flame", "tier6"),
                   new TimedTransition(200, "dead")
                 //   new HealPlayer(5, coolDown: 1000, healAmount: 50)
                 ),
                   new State("dead",
                         new Suicide()
                        ),
                     new State("visible",
                       new SetAltTexture(1),
                         new Order(100, "Crude Flame", "tier6"),
                       new Order(100, "Blood Red Flame", "tier6"),
                       new Order(100, "Blue Flame", "tier6"),
                       new Order(100, "Black Flame", "tier6"),
                       new Order(100, "Ghost Flame", "tier6"),
                       new Order(100, "Amber Flame", "tier6"),
                       new Order(100, "Toxic Flame", "tier6")
                      )
                    )
            )
            .Init("Winter Fountain Frozen", //Frozen <3
                                            //Kabam let it go :DDD
                new State(
                    new HealPlayer(5, coolDown: 450, healAmount: 100)
                    )
            )
            .Init("Nexus Crier",
              new State("Active",
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                 // new BackAndForth(.2, 3),
                  new Taunt(0.4, 10000, "Welcome to Recreo Mortem!", "Use /l20 to instantly give yourself level 20!", "Massive Legend Tokens Drop from dungeons at different drop rates. Use them to buy beta only items.", "Use /showeventpoints to display how many points you have!", "Massive Legend Tokens will only drop during beta!", "Join Our Discord: https://discord.gg/ZZ762Xr")
                  )
                )
            .Init("Sheep",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                    new State("player_nearby",
                        new Prioritize(
                            new StayCloseToSpawn(0.1, 2),
                            new Wander(0.1)
                            ),
                        new Taunt(0.001, 1000, "baa", "baa baa")
                        )
                    )
            );
    }
}