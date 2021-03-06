﻿using System;
using System.Collections.Generic;
using System.Text;
using TimeRecorder.Domain.Domain.Clients;
using TimeRecorder.Domain.Domain.Products;
using TimeRecorder.Domain.Domain.WorkProcesses;
using TimeRecorder.Domain.UseCase.Products;
using TimeRecorder.Domain.UseCase.WorkProcesses;
using TimeRecorder.UseCase.Clients;

namespace TimeRecorder.Contents.WorkUnitRecorder.Tasks.Editor
{
    class WorkTaskEditDialogModel
    {
        private readonly WorkProcessUseCase _ProcessUseCase;
        private readonly ClientUseCase _ClientUseCase;
        private readonly ProductUseCase _ProductUseCase;

        public WorkTaskEditDialogModel()
        {
            _ProcessUseCase = new WorkProcessUseCase(ContainerHelper.Resolver.Resolve<IWorkProcessRepository>());
            _ClientUseCase = new ClientUseCase(ContainerHelper.Resolver.Resolve<IClientRepository>());
            _ProductUseCase = new ProductUseCase(ContainerHelper.Resolver.Resolve<IProductRepository>());
        }

        public WorkProcess[] GetProcesses()
        {
            return _ProcessUseCase.GetProcesses();
        }

        public Client[] GetClients()
        {
            var list = new List<Client> { Client.Empty };
            list.AddRange(_ClientUseCase.GetClients());
            return list.ToArray();
        }

        public Product[] GetProducts()
        {
            var list = new List<Product> { Product.Empty };
            list.AddRange(_ProductUseCase.GetProducts());
            return list.ToArray();
        }
    }
}
