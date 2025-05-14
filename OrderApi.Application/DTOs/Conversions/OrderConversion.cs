﻿using OrderApi.Domain.Entities;

namespace OrderApi.Application.DTOs.Conversions
{
    public static class OrderConversion
    {

        public static Order ToEntity(OrderDTO orderDTO) => new Order()
        {
            Id = orderDTO.Id,
            ClientId = orderDTO.ClientId,
            ProductId = orderDTO.ProductId,
            OrderedDate = orderDTO.OrderedDate,
            PurchaseQuantity = orderDTO.PurchaseQuantity
        };


        public static (OrderDTO?, IEnumerable<OrderDTO>?) FromEntity(Order? order, IEnumerable<Order>? orders)
        {
            //return single
            if (order is not null || orders is null)
            {
                var singleOrder = new OrderDTO(
                    order!.Id,
                    order.ClientId,
                    order.ProductId,
                    order.PurchaseQuantity,
                    order.OrderedDate
                    );
                return (singleOrder, null);
            }

            if (orders is not null || order is null)
            {
                var _orders = orders!.Select(o =>

                new OrderDTO(o.Id, o.ProductId, o.ClientId, o.PurchaseQuantity, o.OrderedDate));

                return (null, _orders);
            }
            return(null, null);
        }

    }
}
