﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCSMS.Model;
using HCSMS.Model.Application;
using System.ServiceModel;

namespace HCSMS.Presentation.Impl
{
    public class ItemUI : UserInterface, IItemUI
    {

        private DinningService.DinningServiceClient proxy;
        private InstanceContext context;

        public QueryCriteria Criteria { get; set; }

        public ItemUI(Session session)
            : base(session)
        {
           
        }
        #region IItemUI 成员

        public void CleanItem(List<Item> anItemList)
        {
            throw new NotImplementedException();
        }

        public List<SaleItem> GetItem()
        {
            //InstanceContext context = new InstanceContext(new FrontDeskCallBack());
            using (DinningService.DinningServiceClient proxy = new DinningService.DinningServiceClient())
            {
                try
                {
                    proxy.Open();

                    return proxy.QueryItemList(Criteria);
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                    return null;
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public List<SaleItem> GetRecommendItem()
        {
            //InstanceContext context = new InstanceContext(new FrontDeskCallBack());
            using (DinningService.DinningServiceClient proxy = new DinningService.DinningServiceClient())
            {
                try
                {
                    proxy.Open();

                    return proxy.GetRecommendItem();
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                    return null;
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public List<SpecialOffer> GetSpecialOfferItem(Item anItem)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetUnavailableItem()
        {
            throw new NotImplementedException();
        }

        public void MakeSpecialOffer(Dictionary<Item,List<SpecialOffer>> anOffer)
        {
            //InstanceContext context = new InstanceContext(new FrontDeskCallBack());
            using (DinningService.DinningServiceClient proxy = new DinningService.DinningServiceClient())
            {
                try
                {
                    proxy.Open();
                    foreach (KeyValuePair<Item, List<SpecialOffer>> pair in anOffer)
                    {
                        proxy.SetSpecialOfferForItem(pair.Key, pair.Value);
                    }
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public void RunOutOfItem(List<Item> anItemList)
        {
            throw new NotImplementedException();
        }

        public void SetCriteria(QueryCriteria aCriteria)
        {
            throw new NotImplementedException();
        }

        public void SetItem(List<SaleItem> anItem)
        {
            //InstanceContext context = new InstanceContext(new FrontDeskCallBack());
            using (DinningService.DinningServiceClient proxy = new DinningService.DinningServiceClient())
            {
                try
                {
                    proxy.Open();

                    proxy.SetItem(anItem);
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public void StopSupplyItem(List<Item> anItemList)
        {
            //InstanceContext context = new InstanceContext(new KitchenCallBack());
            using (KitchenService.KitchenServiceClient proxy = new KitchenService.KitchenServiceClient())
            {
                try
                {
                    proxy.Open();

                    proxy.StopSupplyItem(anItemList);
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                  
                }
                catch (Exception ex)
                {
                    raiseError(ex);   
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public void UpdateItem(List<Item> anItem)
        {
            throw new NotImplementedException();
        }

        #endregion      
    }
}
