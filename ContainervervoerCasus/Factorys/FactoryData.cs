﻿using System.Collections.Generic;
using ContainervervoerCasus.Models;

namespace ContainervervoerCasus.Factorys
{
    public class FactoryData
    {
        public List<Container> GetAllContainers()
        {
            List<Container> listAllContainers = new List<Container>
            {
                new Container() {ContainerID = 1, Weight = 4, IsCarying = 0},
                new Container() {ContainerID = 2, Weight = 5, IsCarying = 0},
                new Container() {ContainerID = 3, Weight = 6, IsCarying = 0},
                new Container() {ContainerID = 4, Weight = 7, IsCarying = 0},
                new Container() {ContainerID = 5, Weight = 8, IsCarying = 0},
            };
            return listAllContainers;
        }
    }
}
