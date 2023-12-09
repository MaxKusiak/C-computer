using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Microsoft.VisualBasic;

namespace Project
{
    class Computer
    {
        private MotherBoard mb = null;
        private PowerSupply ps = null;
        public Computer(MotherBoard mb, PowerSupply ps){
            this.mb = mb;
            this.ps = ps;
        }
        // public void setMB(MotherBoard mb){
        //     this.mb = mb;
        // }
        public MotherBoard getMB(){
            return this.mb;
        }
        // public void setPS(PowerSupply ps){
        //     this.ps = ps;
        // }
        public PowerSupply getPS(){
            return this.ps;
        }
        public void showCharacteristics(){
            
        }
    }
    class ComputerComponent
    {
        private string name = "";
        private double cost = 0;
        public ComputerComponent(string name, double cost){
            this.name = name;
            this.cost = cost;
        }
        public string getName(){
            return this.name;
        }
        public double getCost(){
            return this.cost;
        }
    }
    class MotherBoard : ComputerComponent
    {
        private CPU cpu = null;
        private List<RAM> ram = null;
        private List<SSD> ssd = null;
        private GPU gpu = null;
        private Random rnd = new Random();
        public MotherBoard(string name, double cost) : base(name, cost){
            this.cpu = new CPU("CPU", rnd.Next(1, 101), rnd.Next(1, 101));
            int a = rnd.Next(2, 5);
            for(int i = 0; i < a; i++){
                this.ram.Add(new RAM("RAM", rnd.Next(1, 101), rnd.Next(1, 101)));
            }
            a = rnd.Next(1, 3);
            for(int i = 0; i < a; i++){
                this.ssd.Add(new SSD("SSD", rnd.Next(1, 101), rnd.Next(1, 101)));
            }
            this.gpu = new GPU("GPU", rnd.Next(1, 101), rnd.Next(1, 101));
        }
        public CPU getCPU(){
            return this.cpu;
        }
        public List<RAM> getRAM(){
            return this.ram;
        }
        public List<SSD> getSSD(){
            return this.ssd;
        }
        public GPU getGPU(){
            return this.gpu;
        }
    }
    class SSD : ComputerComponent
    {
        private int amount = 0;
        public SSD(string name, double cost, int amount) : base(name, cost){
            this.amount = amount;
        }
    }
    class RAM : ComputerComponent
    {
        private int amount = 0;
        public RAM(string name, double cost, int amount) : base(name, cost){
            this.amount = amount;
        }
    }class CPU : ComputerComponent
    {
        private double frequency = 0;
        public CPU(string name, double cost, double frequency) : base(name, cost){
            this.frequency = frequency;
        }
    }
    class GPU : ComputerComponent
    {
        private int amount = 0;
        public GPU(string name, double cost, int amount) : base(name, cost){
            this.amount = amount;
        }
    }
    class PowerSupply : ComputerComponent
    {
        private double power = 0;
        public PowerSupply(string name, double cost, double power) : base(name, cost){
            this.power = power;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer com = new Computer(new MotherBoard("MotherBoard", 1000), new PowerSupply("PowerSupply", 1001, 220));
            Console.WriteLine($"{com.getMB().getCost()} {com.getMB().getCPU().getName()}");
        }
    }
}