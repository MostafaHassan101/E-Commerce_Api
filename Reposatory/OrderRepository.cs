﻿using Application.Contracts;
using Context;
using Domain.Entities;
using E_Commerce_API.Reposatories;
using Reposatory.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory
{
    public class OrderRepository : Repository<Order, long>, IOrderRepository
    {

        public OrderRepository(DContext context) : base(context)
        { }



        public Task<IEnumerable<Order>> GetAllOrder()
        {
            IEnumerable<Order> orders = _context.Order.ToList();
            return Task.FromResult(orders);
        }
        //public Task<Order> AddOreder(Order order)
        //{
        //          _context.Order.Add(order);
        //	_context.SaveChanges();
        //	return Task.FromResult(order);
        //}
        
        public Task<Order> AddOreder(OrderDTO order)
        {
            User user = _context.Users.Where(a => a.Id == order.UserId).FirstOrDefault();

            List<OrderItems> OrderItems = new List<OrderItems>();


            foreach (var ord in order.OrderItemsDTO)
            {
                OrderItems orderitem1 = new OrderItems();
                Product p = _context.Product.Where(a => a.Id == ord.ProductId).FirstOrDefault();
                orderitem1.Product = p;
                orderitem1.ProductId = ord.ProductId;
                orderitem1.Quantity = ord.Quantity;
                OrderItems.Add(orderitem1);
            }

            Order order1 = new Order();
            order1.Address = order.Address;
            order1.AddressAr = order.AddressAr;
            order1.PaymentMethod = order.PaymentMethod;
            //order1.PaymentStatus = order.PaymentStatus;
            order1.TotalPrice = order.TotalPrice;
            order1.OrderItems = OrderItems;
            order1.User = user;
            _context.Order.Add(order1);
            _context.SaveChanges();
            return Task.FromResult(order1);

        }

        
    }
}
