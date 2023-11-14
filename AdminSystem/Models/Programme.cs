using System;
using System.ComponentModel.DataAnnotations;

namespace AdminSystem.Models
{
	public class Programme
	{
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public int NumberOfModules { get; set; }

        public int Code { get; set; }

        public int NumberOfOptionalModules { get; set; }

        private static int ONE_YEAR_MODULE_SIZE = 6;

        private static int TWO_YEAR_MODULE_SIZE = 12;

        public static int GetProgramModuleSize(int duration)
        {
            if(duration == 1) {
                return ONE_YEAR_MODULE_SIZE;
            }
            else if(duration == 2){
                return TWO_YEAR_MODULE_SIZE;
            }
            else
            {
                return 0;
            }
        }
        
    }


}

